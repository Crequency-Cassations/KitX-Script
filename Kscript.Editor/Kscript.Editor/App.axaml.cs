using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using Kscript.Editor.Data;
using Kscript.Editor.ViewModels;
using Kscript.Editor.Views;

namespace Kscript.Editor;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainWin = new MainWindow
            {
                DataContext = new MainViewModel()
            };
            desktop.MainWindow = mainWin;

            nameof(MainWindow).RegisterWindowHandle(mainWin.PlatformImpl?.Handle.Handle);

            nameof(GlobalInfo.WindowHandles).InvokeReactor();
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
