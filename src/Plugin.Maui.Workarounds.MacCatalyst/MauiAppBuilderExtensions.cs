using Microsoft.Maui.LifecycleEvents;

namespace Plugin.Maui.Workarounds.MacCatalyst;

/// <summary>
/// TODO: Provide relevant comments for your APIs
/// </summary>
public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseMacCatalystWorkarounds(this MauiAppBuilder builder)
        => builder
            .UseHideTitlebarSeparator();

    public static MauiAppBuilder UseHideTitlebarSeparator(this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events =>
        {
            events.AddiOS(iOS =>
            {
                iOS.SceneWillConnect((scene, session, options) =>
                {
                    if (scene is not UIKit.UIWindowScene windowScene)
                        return;

                    // Hide the titlebar separator
                    if (windowScene.Titlebar is { } titlebar)
                    {
                        titlebar.SeparatorStyle = UIKit.UITitlebarSeparatorStyle.None;
                    }
                });
            });
        });

        return builder;
    }
}
