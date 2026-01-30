using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityRent_Utilities
{
    public static class Logger
    {
        private static readonly string SourceName = "Velocity Rent";
        private static readonly string LogName = "Application"; // Windows default log

        static Logger() => TryConfigure();

        private static void TryConfigure()
        {
            try
            {
                if (!EventLog.SourceExists(SourceName))
                    EventLog.CreateEventSource(SourceName, LogName);
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"[Logger Warning] Failed to configure event source: {ex.Message}");
            }
        }

        public static void Error(string message) => LogInternal(message, EventLogEntryType.Error);
        public static void Warning(string message) => LogInternal(message, EventLogEntryType.Warning);
        public static void Information(string message) => LogInternal(message, EventLogEntryType.Information);
        private static void LogInternal(string message,EventLogEntryType type)
        {
            try
            {
                EventLog.WriteEntry(SourceName, message, type);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"[Logger Error] Failed to write to Event Log: {ex.Message}");
            }
        }
    }
}
