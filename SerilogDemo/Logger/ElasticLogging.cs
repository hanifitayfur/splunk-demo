using System;
using System.Configuration;
using Serilog;

namespace SerilogDemo.Logger
{
    public class ElasticLogging : ILog
    {
        private readonly Serilog.Core.Logger _logger;
        private readonly string elasticIndexFormat = "log-{0:yyyy.MM.dd}";

        public ElasticLogging()
        {
          
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
