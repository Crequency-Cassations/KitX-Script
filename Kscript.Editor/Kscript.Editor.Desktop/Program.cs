using Avalonia;
using Avalonia.ReactiveUI;
using Kscript.Editor.Data;
using Kscript.Editor.Desktop.PInvoke;
using Kscript.Editor.Views;
using System;

namespace Kscript.Editor.Desktop
{
    internal class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args)
        {
            if (OperatingSystem.IsWindows())
            {
                nameof(GlobalInfo.WindowHandles).RegisterInfoReactor(() =>
                    WindowStyle.UpdateStyleAttributes(nameof(MainWindow).RequestWindowHandle()));
            }

            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI();
    }
}
