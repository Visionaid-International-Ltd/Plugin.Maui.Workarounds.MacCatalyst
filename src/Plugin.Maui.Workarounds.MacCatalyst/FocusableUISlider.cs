using UIKit;

namespace Plugin.Maui.Workarounds.MacCatalyst;

public class FocusableUISlider : UISlider
{
    public FocusableUISlider()
        : base()
    {
    }

    public override bool CanBecomeFocused => true;
}
