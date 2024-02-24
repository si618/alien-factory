namespace AlienFactory.ViewModels;

public class LogsViewModel : ViewModelBase
{
    public string Tail => ResourceBuilder.GetResource(nameof(LogsViewModel), nameof(Tail));
}
