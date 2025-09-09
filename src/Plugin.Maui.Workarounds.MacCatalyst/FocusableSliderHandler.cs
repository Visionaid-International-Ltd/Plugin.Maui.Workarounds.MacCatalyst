using Microsoft.Maui.Handlers;
using UIKit;

namespace Plugin.Maui.Workarounds.MacCatalyst;

public partial class FocusableSliderHandler : SliderHandler
{
    protected override UISlider CreatePlatformView() => new FocusableUISlider();
}
