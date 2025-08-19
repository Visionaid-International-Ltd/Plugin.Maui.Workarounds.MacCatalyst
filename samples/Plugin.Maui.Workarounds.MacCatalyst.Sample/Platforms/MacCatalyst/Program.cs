using UIKit;
using Plugin.Maui.Workarounds.MacCatalyst.Binding;

namespace Plugin.Maui.Workarounds.MacCatalyst.Sample;

public class Program
{
    // This is the main entry point of the application.
    static void Main(string[] args)
    {
        MacCatalystWorkarounds.OverrideCatalystScaleFactor();

        // if you want to use a different Application Delegate class from "AppDelegate"
        // you can specify it here.
        UIApplication.Main(args, null, typeof(AppDelegate));
    }
}
