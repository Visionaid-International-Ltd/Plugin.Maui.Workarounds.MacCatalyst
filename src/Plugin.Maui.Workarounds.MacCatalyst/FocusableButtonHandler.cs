using Microsoft.Maui.Handlers;
using UIKit;

namespace Plugin.Maui.Workarounds.MacCatalyst;

public partial class FocusableButtonHandler : ButtonHandler
{
    protected override UIButton CreatePlatformView() => new FocusableUIButton();
}
