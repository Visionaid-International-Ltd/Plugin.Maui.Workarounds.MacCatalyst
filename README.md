# Plugin.Maui.Workarounds.MacCatalyst

`Plugin.Maui.Workarounds.MacCatalyst` provides the ability to do this amazing thing in your .NET MAUI application.

## Install Plugin

[![NuGet](https://img.shields.io/nuget/v/Plugin.Maui.Workarounds.MacCatalyst.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.Maui.Workarounds.MacCatalyst/)

Install with the dotnet CLI: `dotnet add package Plugin.Maui.Workarounds.MacCatalyst`, or through the NuGet Package
Manager in Visual Studio.

## Workarounds

### Disable Mac Catalyst scaling

Mac Catalyst (and therefore MAUI) uses the "iPad idiom" by default, which scales down to 77% on macOS. This reduce
detail and causes performance issues for Metal views etc.

https://developer.apple.com/design/human-interface-guidelines/mac-catalyst#Choose-an-idiom

Unfortunately, `UIPickerView` and some other controls are not available when using the "Mac idiom" which means that
the MAUI `Picker` control cannot be used.

A workaround is provided to swizzle some of the private methods to disable Mac Catalyst's scaling while still
using the "iPad idiom". *It is unclear whether this might constiture private API usage and therefore make the app
ineligible for App Store distrubution*. To that end the developer must determine the suitability of this package
for their use and assumes all the risk - no warranty of any kind is provided.

Upstream issue: https://github.com/dotnet/maui/issues/10622

### Handler for focusable Buttons to support keyboard navigation

`UIButton` cannot become focused by default, and the constructor that MAUI uses for `UIButton` does not support
sub-classing. This complicates supporting keyboard navigation on macOS, which may be required for EAA compliance.

A workaround is provided via a MAUI handler that allows `UIButton`s to become focused.

### NSLog redirection to the debug console

The macios bindings have calls to `NSLog` for warning and debug messages. However, `NSLog` writes to `stderr` and so
does not appear on the debug console (when debugging with VS Code for instance).

A workaround is provided to redirect stderr to the trace listeners if desired.

## Example usage

A sample app is provided in the [source repository](https://github.com/Visionaid-International-Ltd/Plugin.Maui.Workarounds.MacCatalyst).

```csharp
using Plugin.Maui.Workarounds.MacCatalyst;

public class Program
{
    // This is the main entry point of the application.
    static void Main(string[] args)
    {
        Workarounds.RedirectNSLogToTrace();

        Workarounds.OverrideCatalystScaleFactor();

        // if you want to use a different Application Delegate class from "AppDelegate"
        // you can specify it here.
        UIApplication.Main(args, null, typeof(AppDelegate));
    }
}
```

```csharp
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseFocusableButtonHandler()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddTransient<MainPage>();

        return builder.Build();
    }
}
```

## License

This project is licensed under the [MIT](https://github.com/dotnet/macios/blob/main/LICENSE) License.

## Acknowledgements

Thanks to @jfversluis for the template project and @JunyuKuang for the Swift implementation of the scale factor override.
Special thanks to @rolfbjarne for his invaluable efforts on the [macios](https://github.com/dotnet/macios/) project.
