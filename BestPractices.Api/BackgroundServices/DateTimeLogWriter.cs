namespace BestPractices.Api.BackgroundServices;

public class DateTimeLogWriter2 : BackgroundService
{
    public override Task StartAsync(CancellationToken cancellationToken)
    {
        return base.StartAsync(cancellationToken);
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        return base.StopAsync(cancellationToken);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return null;
    }
}
public class DateTimeLogWriter: IHostedService,IDisposable
{
    private Timer _timer;
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"{nameof(DateTimeLogWriter)} Services started ...");
        _timer = new Timer(WriteDateTimmeLong, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        return Task.CompletedTask;
    }

    private void WriteDateTimmeLong(object state)
    {
        _timer?.Change(Timeout.Infinite, 0);
        Console.WriteLine($"Datetime is {DateTime.Now.ToLongTimeString()}");
    }
    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"{nameof(DateTimeLogWriter)} Service stopped  ...");
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer.Dispose();
    }
}