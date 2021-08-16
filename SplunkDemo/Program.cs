using System;
using System.Diagnostics;
using Splunk.Logging;

namespace SplunkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            EnableSelfSignedCertificates();

            TraceListenerExample();
        }

        private static void TraceListenerExample()
        {
            // Replace with your HEC token
            string token = "44726b92-e0ab-4356-91da-a2217943ae78";

            // TraceListener
            var trace = new TraceSource("dod-logger", SourceLevels.All);
            var listener = new HttpEventCollectorTraceListener(
                uri: new Uri("http://localhost:8088"),
                token: token,
                batchSizeCount: 1);
            trace.Listeners.Add(listener);

            // Send some events
            // trace.TraceEvent(TraceEventType.Error, 0, "Hanifi-1-Errır");
            trace.TraceEvent(TraceEventType.Information,new Random().Next(1,11111), "Ops-Hanifi-2");
            trace.TraceEvent(TraceEventType.Information,new Random().Next(1,11111), "Ops-Hanifi-3");
            // trace.TraceData(TraceEventType.Error, 3, "Hanifi-4");
            // trace.TraceData(TraceEventType.Information, 4, "Hanifi-5");
            trace.Close();

            // Now search splunk index that used by your HEC token you should see above 5 events are indexed
        }
        
        private static void EnableSelfSignedCertificates()
        {
            // Enable self signed certificates
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                delegate
                {
                    return true;
                };
        }
        
    }
}


