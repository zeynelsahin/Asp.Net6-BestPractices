namespace BestPractices.Api.Logging;

public class MyCustomLoggerFactory : ILoggerProvider
{
    public void Dispose()
    {
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new MyCustomLogger();
    }
}

public class MyCustomLogger : ILogger
{
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        string logMsg = formatter(state, exception);
        logMsg = $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] - {logMsg}";
        Console.WriteLine(logMsg);
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }
}