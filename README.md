![nuget.png](https://raw.githubusercontent.com/Visionaid-International-Ltd/Plugin.Maui.Workarounds.MacCatalyst/main/nuget.png)

# Plugin.Maui.Workarounds.MacCatalyst

`Plugin.Maui.Workarounds.MacCatalyst` provides the ability to do this amazing thing in your .NET MAUI application.

## Install Plugin

[![NuGet](https://img.shields.io/nuget/v/Plugin.Maui.Workarounds.MacCatalyst.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.Maui.Workarounds.MacCatalyst/)

Available on [NuGet](http://www.nuget.org/packages/Plugin.Maui.Workarounds.MacCatalyst).

Install with the dotnet CLI: `dotnet add package Plugin.Maui.Workarounds.MacCatalyst`, or through the NuGet Package Manager in Visual Studio.

## API Usage

```csharp
public class Program
{
    // This is the main entry point of the application.
    static void Main(string[] args)
    {
        Workarounds.OverrideCatalystScaleFactor();

        // if you want to use a different Application Delegate class from "AppDelegate"
        // you can specify it here.
        UIApplication.Main(args, null, typeof(AppDelegate));
    }
}
```
