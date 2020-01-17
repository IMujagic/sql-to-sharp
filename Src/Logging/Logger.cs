using System;
using SqlToSharp.Common;
using SqlToSharp.Logging.Providers;

namespace SqlToSharp.Logging
{
    public static class Logger
    {
        private static readonly ILogProvider _logProvider = new ConsoleLogProvider();

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