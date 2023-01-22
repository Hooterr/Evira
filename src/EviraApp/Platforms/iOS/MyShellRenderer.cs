using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Controls.PlatformConfiguration;
using UIKit;
namespace Evira.App.Platforms;

public class MyShellRenderer : ShellRenderer
{
    protected override IShellSectionRenderer CreateShellSectionRenderer(ShellSection shellSection)
    {
        var renderer = base.CreateShellSectionRenderer(shellSection);
        if (renderer != null)
        {
            
        }
        return renderer;
    }

    protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
    {
        return new MyShellTabBarAppearanceTracker();
    }
}


public class MyShellTabBarAppearanceTracker : SafeShellTabBarAppearanceTracker
{
    public override void SetAppearance(UITabBarController controller, ShellAppearance appearance)
    {
        if (OperatingSystem.IsIOSVersionAtLeast(15, 0))
        {
            var uiAppearance = new UITabBarAppearance();
            uiAppearance.ConfigureWithOpaqueBackground();
            typeof(SafeShellTabBarAppearanceTracker).GetField("_tabBarAppearance", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, uiAppearance);
        }
        base.SetAppearance(controller, appearance);
    }
}