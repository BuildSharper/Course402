namespace BuildSharper.Course402.WebCore.Services.Interfaces
{
    public interface ILogService
    {
        void Log(string message, Exception? exception = null);
    }
}
