namespace Plugin.Maui.Workarounds.MacCatalyst;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseFocusableButtonHandler(this MauiAppBuilder builder)
        => builder.ConfigureMauiHandlers(handlers => handlers.AddHandler<Button, FocusableButtonHandler>());

    public static MauiAppBuilder UseFocusableSliderHandler(this MauiAppBuilder builder)
        => builder.ConfigureMauiHandlers(handlers => handlers.AddHandler<Slider, FocusableSliderHandler>());
}
