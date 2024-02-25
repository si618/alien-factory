namespace AlienFactory.ViewModels;

public class SettingsViewModel : ViewModelBase
{
    public string ShowSettings => ResourceBuilder
        .GetResource(nameof(SettingsViewModel), nameof(ShowSettings));
}
