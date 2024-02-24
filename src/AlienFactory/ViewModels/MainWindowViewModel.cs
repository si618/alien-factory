namespace AlienFactory.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ActionsViewModel ActionsViewModel { get; } = new();
    public DevicesViewModel DevicesViewModel { get; } = new();
    public LogsViewModel LogsViewModel { get; } = new();
    public SettingsViewModel SettingsViewModel { get; } = new();

    public string Greeting => ResourceBuilder
        .GetResource(nameof(MainWindowViewModel), nameof(Greeting));
    public string Title => ResourceBuilder
        .GetResource(nameof(MainWindowViewModel), nameof(Title));
}
