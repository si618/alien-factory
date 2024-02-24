namespace AlienFactory;

using Avalonia;
using Avalonia.ReactiveUI;
using Serilog;

internal static class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        try
        {
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }
        catch (Exception e)
        {
            Log.Fatal(e, "Rapid Unscheduled Disassembly 🧐");
        }
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    private static AppBuilder BuildAvaloniaApp()
    {
        Log.Logger = new LoggerConfiguration()
            //.Filter.ByIncludingOnly(Matching.WithProperty("Area", LogArea.Control))
            .MinimumLevel.Verbose()
            .WriteTo.Console()
            .WriteTo.Trace()
            .CreateLogger();

        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToSerilog()
            .LogToTrace()
            .UseReactiveUI();
    }
}