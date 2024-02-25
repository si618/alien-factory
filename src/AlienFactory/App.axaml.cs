namespace AlienFactory;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using Serilog;
using ViewModels;
using Views;

public partial class App : Application
{
    private MainWindow? _mainWindow;

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

            desktop.ShutdownRequested += ShutdownRequested;
        }

        base.OnFrameworkInitializationCompleted();
        Log.Debug("Alien Factory initialized");
    }

    private static void ShutdownRequested(object? sender, ShutdownRequestedEventArgs e)
    {
        Log.Debug("Alien Factory shutting down");
    }

    private void MainWindow_PropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
    {
        if (sender is not MainWindow || e.NewValue is not WindowState.Minimized)
        {
            return;
        }

        Log.Debug("Hiding main window");
        _mainWindow?.Hide();
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

        Log.Information("Showing main window");
        _mainWindow.WindowState = WindowState.Normal;
        _mainWindow.Show();
    }
}