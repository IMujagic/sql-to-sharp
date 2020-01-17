using System;

namespace SqlToSharp.Logging.Providers
{
    public interface ILogProvider
    {
        void Error(string message);
        void Exception(Exception ex);
        void Info(string message);
        void Warning(string message);
    }
}