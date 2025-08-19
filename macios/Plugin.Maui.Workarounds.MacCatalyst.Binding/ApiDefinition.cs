using Foundation;

namespace Plugin.Maui.Workarounds.MacCatalyst.Binding;

// @interface DotnetCharts : NSObject
[BaseType(typeof(NSObject))]
interface MacCatalystWorkarounds
{
    // +(NSString * _Nonnull)overrideCatalystScaleFactor:(NSString * _Nonnull)myString __attribute__((warn_unused_result("")));
    [Static]
    [Export("overrideCatalystScaleFactor")]
    void OverrideCatalystScaleFactor();
}