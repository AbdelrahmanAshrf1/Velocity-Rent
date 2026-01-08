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
        private static readonly string _SourceName = "Velocity Rent";
        
        static Logger()
        {
            _Configure();
        }

        private static void _Configure()
        {
            try
            {
                if (!EventLog.SourceExists(_SourceName))
                    EventLog.CreateEventSource(_SourceName, "Application");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"[Logger Warning] Failed to configure event source: {ex.Message}");
            }
        }

        public static void ErrorLog(string message) => _Log(message, EventLogEntryType.Error);
        public static void WarningLog(string message) => _Log(message, EventLogEntryType.Warning);
        public static void InformationLog(string message) => _Log(message, EventLogEntryType.Information);
        private static void _Log(string message,EventLogEntryType type)
        {
            try
            {
                EventLog.WriteEntry(_SourceName, message, type);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"[Logger Error] Failed to write to Event Log: {ex.Message}");
            }
        }
    }
}
