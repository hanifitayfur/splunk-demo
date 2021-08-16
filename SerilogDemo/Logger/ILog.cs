namespace SerilogDemo.Logger
{
    public interface ILog
    {
        void Error(string message);
        void Information(string innerExceptionMessage);
    }
}