using Android.App;
using Android.Content.PM;
using Avalonia.Android;

namespace Kscript.Editor.Android
{
    [Activity(Label = "Kscript.Editor.Android", Theme = "@style/MyTheme.NoActionBar", Icon = "@drawable/icon", LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class MainActivity : AvaloniaMainActivity
    {
    }
}