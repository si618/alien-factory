namespace AlienFactory;

using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using ReactiveUI;
using System.Reactive;
using System.Reflection;

internal static class TrayIconsFactory
{
    public static TrayIcons BuildTrayIcons(ReactiveCommand<Unit, Unit> reactiveCommand)
    {
        var toolTipText =
            ResourceBuilder.GetResource(nameof(TrayIconsFactory),
            TrayIcon.ToolTipTextProperty.Name);
        var trayIcon = new TrayIcon
        {
            IsVisible = true,
            ToolTipText = toolTipText,
            Icon = new WindowIcon(BuildBitmap()),
            Command = reactiveCommand,
            Menu = BuildNativeManu()
        };

        return [trayIcon];
    }

    private static Bitmap BuildBitmap()
    {
        var uri = new Uri($"avares://{Assembly.GetExecutingAssembly().GetName().Name}/Assets/alien.png");
        return new Bitmap(AssetLoader.Open(uri));
    }

    private static NativeMenu BuildNativeManu()
    {
        var exitHeader =
            ResourceBuilder.GetResource($"{nameof(NativeMenuItem)}_Exit",
            NativeMenuItem.HeaderProperty.Name);
        var menu = new NativeMenu();
        menu.Items.Add(new NativeMenuItem
        {
            Header = exitHeader,
            Command = ReactiveCommand.Create(() => Environment.Exit(0))
        });
        return menu;
    }
}
