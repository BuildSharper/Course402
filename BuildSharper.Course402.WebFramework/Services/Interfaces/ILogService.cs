using System;

namespace BuildSharper.Course402.WebFramework.Services.Interfaces
{
    public interface ILogService
    {
        void Log(string message, Exception exception = null);
    }
}
