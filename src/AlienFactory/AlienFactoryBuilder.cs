namespace AlienFactory;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models;
using OpenRGB.NET;

public interface IAlienFactoryBuilder
{
    event EventHandler<OpenRgbClientSettings> OnSettingsChanged;

    IOpenRgbClient Build();
}

public class AlienFactoryBuilder : IAlienFactoryBuilder
{
    private readonly OpenRgbClientSettings _settings;
    private readonly ILogger<AlienFactoryBuilder> _logger;

    public AlienFactoryBuilder(
        ILogger<AlienFactoryBuilder> logger,
        IOptionsMonitor<OpenRgbClientSettings> options)
    {
        _logger = logger;
        _settings = options.CurrentValue;
        options.OnChange(settings =>
        {
            _logger.LogInformation("Settings changed");
            OnSettingsChanged?.Invoke(this, settings);
        });
    }

    public event EventHandler<OpenRgbClientSettings>? OnSettingsChanged;

    public IOpenRgbClient Build()
    {
        _logger.LogInformation("Building OpenRGB client with settings {Settings}", _settings);
        return new OpenRgbClient(
            _settings.IpAddress,
            _settings.Port,
            _settings.Name,
            _settings.AutoConnect,
            _settings.TimeoutMs,
            _settings.ProtocolVersionNumber);
    }
}
