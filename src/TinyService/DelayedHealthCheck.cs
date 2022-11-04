using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;

namespace TinyService
{
    public class DelayedHealthCheck : IHealthCheck
    {
        private readonly TimeSpan _delay;

        public DelayedHealthCheck(IOptions<AppOptions> appOptions)
        {
            _delay = TimeSpan.FromSeconds(appOptions.Value.HealthCheckDelay);
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
            CancellationToken cancellationToken = new CancellationToken())
        {
            await Task.Delay(_delay, cancellationToken);

            return HealthCheckResult.Healthy("ok");
        }
    }
}
