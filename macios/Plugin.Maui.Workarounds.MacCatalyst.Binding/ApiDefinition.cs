using Foundation;
using UIKit;

namespace Plugin.Maui.Workarounds.MacCatalyst.Binding;

// @interface DotnetCharts : NSObject
[BaseType(typeof(NSObject))]
interface MacCatalystWorkarounds
{
    // +(void)overrideCatalystScaleFactor;
    [Static]
    [Export("overrideCatalystScaleFactor")]
    void OverrideCatalystScaleFactor();
}