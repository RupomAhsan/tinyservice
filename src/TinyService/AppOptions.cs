namespace TinyService
{
    public class AppOptions
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public string File { get; set; }
        public string AnotherServiceUrl { get; set; }
        public int HealthCheckDelay { get; set; }
        public int ReadinessCheckDelay { get; set; }
        public bool LogRequestHeaders { get; set; }
    }
}
