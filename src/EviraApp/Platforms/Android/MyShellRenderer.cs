using Android.Content;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;

namespace Evira.App.Platforms;

public class MyShellRenderer : ShellRenderer
{
    public MyShellRenderer(Context context) : base(context)
    {
    }

    protected override IShellToolbarAppearanceTracker CreateToolbarAppearanceTracker()
    {
        return new MyShellToolbarAppearanceTracker(this);
    }
}

public class MyShellToolbarAppearanceTracker : ShellToolbarAppearanceTracker
{
    public MyShellToolbarAppearanceTracker(IShellContext context) : base(context)
    {
    }

    public override void SetAppearance(AndroidX.AppCompat.Widget.Toolbar toolbar, IShellToolbarTracker toolbarTracker, ShellAppearance appearance)
    {
        base.SetAppearance(toolbar, toolbarTracker, appearance);
        toolbar.SetBackgroundColor(Android.Graphics.Color.ParseColor("#0075BE"));
    }
}
