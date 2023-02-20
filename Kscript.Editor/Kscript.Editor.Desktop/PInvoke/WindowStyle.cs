using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Kscript.Editor.Desktop.PInvoke;

public class WindowStyle
{
    [DllImport("dwmapi.dll")]
    public static extern int DwmSetWindowAttribute(IntPtr hwnd, DwmWindowAttribute dwAttribute,
        ref int pvAttribute, int cbAttribute);

    [Flags]
    public enum DwmWindowAttribute : uint
    {
        DWMWA_USE_HOSTBACKDROPBRUSH = 17,
        DWMWA_USE_IMMERSIVE_DARK_MODE = 20,
        DWMWA_SYSTEMBACKDROP_TYPE = 38,
        DWMWA_MICA_EFFECT = 1029,
    }

    [Flags]
    public enum DwmSystemBackDropType : int
    {
        DWMSBT_AUTO,
        DWMSBT_NONE,
        DWMSBT_MAINWINDOW = 2,      //  Mica
        DWMSBT_TRANSIENTWINDOW = 3, //  Acrylic
        DWMSBT_TABBEDWINDOW = 4,    //  Tabbed

        Mica = 2,
        Acrylic = 3,
        Tabbed = 4
    }

    public static void UpdateStyleAttributes(nint hwnd)
    {
        int trueValue = 0x01;
        //int backDrop = (int)DwmSystemBackDropType.Tabbed;

        _ = DwmSetWindowAttribute(hwnd, DwmWindowAttribute.DWMWA_MICA_EFFECT,
            ref trueValue, Marshal.SizeOf(typeof(int)));
        _ = DwmSetWindowAttribute(hwnd, DwmWindowAttribute.DWMWA_USE_IMMERSIVE_DARK_MODE,
            ref trueValue, Marshal.SizeOf(typeof(int)));
        //_ = DwmSetWindowAttribute(hwnd, DwmWindowAttribute.DWMWA_SYSTEMBACKDROP_TYPE,
        //    ref backDrop, Marshal.SizeOf(typeof(int)));
    }
}
