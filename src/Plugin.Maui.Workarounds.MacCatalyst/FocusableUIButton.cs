using UIKit;

namespace Plugin.Maui.Workarounds.MacCatalyst;

public class FocusableUIButton : UIButton
{
    public FocusableUIButton()
        : base()
    {
    }

    public override bool CanBecomeFocused => true;
}
