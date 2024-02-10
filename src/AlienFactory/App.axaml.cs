namespace AlienFactory;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using ViewModels;
using Views;

public partial class App : Application
{
    private MainWindow? _mainWindow;

    private void MainWindow_PropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
    {
        if (sender is MainWindow && e.NewValue is WindowState.Minimized)
        {
            _mainWindow?.Hide();
        }
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            _mainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
            desktop.MainWindow = _mainWindow;
            _mainWindow.PropertyChanged += MainWindow_PropertyChanged;

            RegisterTrayIcon();
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void RegisterTrayIcon()
    {
        var trayIcons = TrayIconsFactory.BuildTrayIcons(ReactiveCommand.Create(ShowApplication));
        SetValue(TrayIcon.IconsProperty, trayIcons);
    }

    private void ShowApplication()
    {
        if (_mainWindow is null)
        {
            return;
        }

        _mainWindow.WindowState = WindowState.Normal;
        _mainWindow.Show();
    }
}