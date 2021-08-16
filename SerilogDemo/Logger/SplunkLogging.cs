using Serilog;

namespace SerilogDemo.Logger
{
    public class SplunkLogging : ILog
    {
        private readonly Serilog.Core.Logger _logger;
        private const string Token = "44726b92-e0ab-4356-91da-a2217943ae78";
        private const string SplunkUrl = "http://localhost:8088/services/collector";

        public SplunkLogging()
        {
            _logger = new LoggerConfiguration()
                .WriteTo.EventCollector(SplunkUrl, Token)
                .CreateLogger();
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Information(string message)
        {
            _logger.Information(message);
        }
    }
}