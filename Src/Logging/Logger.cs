using System;
using SqlToSharp.Common;
using SqlToSharp.Logging.Providers;

namespace SqlToSharp.Logging
{
    public static class Logger
    {
        private static ILogProvider _logProvider;

        public static void SetProvider(ILogProvider logProvider)
        {
            if(_logProvider != null)
                throw new Exception("Log provider is already set!");

            _logProvider = logProvider;
        }

        public static void Info(string message)
        {
            _logProvider.Info(message);
        }
        
        public static void Warning(string message)
        {
            _logProvider.Warning(message);
        }
        
        public static void Error(string message)
        {
            _logProvider.Error(message);
        }
        
        public static void Exception(Exception ex)
        {
            _logProvider.Error(ex.Format());
        }
    }
}