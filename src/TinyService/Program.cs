using Microsoft.Extensions.DependencyInjection;
using System.Text;
using TinyService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRouting();

var options = builder.Configuration.GetSection("app").Get<AppOptions>();

builder.Services.AddHttpClient().Configure <AppOptions>
 (   options =>
{
    options = options;
});

builder.Services.AddHealthChecks().AddCheck<DelayedHealthCheck>("delayed");

var logger = builder.Logging.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();


var id = GetOption(nameof(options.Id), options.Id);

string GetOption(string property, string value)
            => Environment.GetEnvironmentVariable($"Tiny_{property.ToUpperInvariant()}") ?? value;

if (string.IsNullOrWhiteSpace(id))
{
    id = Guid.NewGuid().ToString("N");
}

logger.LogInformation($"TinyService ID: {id}");
var message = GetOption(nameof(options.Message), options.Message);
var file = GetOption(nameof(options.File), options.File);
var anotherServiceUrl = GetOption(nameof(options.AnotherServiceUrl),
    options.AnotherServiceUrl);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseDeveloperExceptionPage();
app.UseHealthChecks("/health");
app.UseHttpsRedirection();

if (options.LogRequestHeaders)
{
    logger.LogInformation("Logging request headers enabled.");
    app.Use(async (ctx, next) =>
    {
        var builder = new StringBuilder(Environment.NewLine);
        foreach (var (key, value) in ctx.Request.Headers)
        {
            builder.AppendLine($"{key}:{value}");
        }

        logger.LogInformation(builder.ToString());
        await next();
    });
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("", ctx => ctx.Response.WriteAsync($"{message} [ID: {id}]"));
    endpoints.MapGet("id", ctx => ctx.Response.WriteAsync(id));
    endpoints.MapGet("ready", async ctx =>
    {
        await Task.Delay(TimeSpan.FromSeconds(options.ReadinessCheckDelay));
        await ctx.Response.WriteAsync("ready");
    });
    endpoints.MapGet("getText", ctx =>
        ctx.Response.WriteAsync(File.Exists(file)
            ? File.ReadAllText(file)
            : $"Text File: '{file}' was not found."));
    endpoints.MapGet("another", async ctx =>
    {
        var httpClient = ctx.RequestServices.GetService<IHttpClientFactory>()
            .CreateClient();
        var nextMessage = await httpClient.GetStringAsync(anotherServiceUrl);
        await ctx.Response.WriteAsync($"Received a message: {nextMessage}");
    });
});



app.Run();

