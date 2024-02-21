namespace AlienFactory;

using Microsoft.Extensions.Logging;

public interface IAlienFactory
{
    void Connect();
    void Start();
    void Stop();
}

public class AlienFactory : IAlienFactory
{
    private readonly ILogger<AlienFactory> _logger;
    private readonly IAlienFactoryBuilder _builder;

    public AlienFactory(ILogger<AlienFactory> logger, IAlienFactoryBuilder builder)
    {
        _logger = logger;
        _builder = builder;
        _builder.OnSettingsChanged += (sender, settings) =>
        {
            _logger.LogInformation("Reconnecting as settings changed");
            Connect();
        };
    }

    public void Connect()
    {
        var client = _builder.Build();

        _logger.LogInformation("Connecting to {Client}", client);

        // Connect not needed if AutoConnect is true
        if (!client.Connected)
        {
            client.Connect();
        }
    }

    public void Start()
    {
        throw new NotImplementedException();
    }

    public void Stop()
    {
        throw new NotImplementedException();
    }
}
