namespace AlienFactory.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => ResourceBuilder.GetResource(nameof(MainWindowViewModel), nameof(Greeting));
    public string Title => ResourceBuilder.GetResource(nameof(MainWindowViewModel), nameof(Title));
}
