#nullable enable
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using UIKit;

namespace Evira.App.Platforms;

public class MyShellRenderer : ShellRenderer
{
    protected override IShellSectionRenderer CreateShellSectionRenderer(ShellSection shellSection)
    {
        return new MyShellSectionRenderer(this);
    }

    protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
    {
        return new MyShellTabBarAppearanceTracker();
    }
}


public class MyShellSectionRenderer : ShellSectionRenderer
{
    private static readonly Lazy<Func<ShellSection, bool, IMauiContext?>> _lazyFindMauiContext = new Lazy<Func<ShellSection, bool, IMauiContext?>>(CreateDelegate);

    private static Func<ShellSection, bool, IMauiContext?> CreateDelegate()
    {
        var methodInfo = typeof(Microsoft.Maui.Controls.ViewExtensions).GetMethod("FindMauiContext",
            BindingFlags.Static | BindingFlags.NonPublic);

        ArgumentNullException.ThrowIfNull(methodInfo);

        return (Func<ShellSection, bool, IMauiContext?>)System.Delegate.CreateDelegate(typeof(Func<ShellSection, bool, IMauiContext?>), methodInfo);
    }

    private static Func<ShellSection, bool, IMauiContext?> FindMauiContext => _lazyFindMauiContext.Value;

    public MyShellSectionRenderer(IShellContext context) : base(context)
    {
    }

    protected override void UpdateTabBarItem()
    {
        Title = ShellSection.Title;

        var context = FindMauiContext(ShellSection, false);
            
        ShellSection.Icon.LoadImage(context!, icon =>
        {
            TabBarItem = new UITabBarItem(ShellSection.Title, icon?.Value, null);
            TabBarItem.AccessibilityIdentifier = ShellSection.AutomationId ?? ShellSection.Title;

            var selectedImageSource = AttachedProperties.SelectedIconProperty.GetSource(ShellSection.CurrentItem);
            if (selectedImageSource == null)
            {
                return;
            }

            selectedImageSource.LoadImage(context!, icon =>
            {
                TabBarItem.SelectedImage = icon!.Value;
            });
        });
    }
}

public class MyShellTabBarAppearanceTracker : SafeShellTabBarAppearanceTracker
{
    public override void SetAppearance(UITabBarController controller, ShellAppearance appearance)
    {
        controller.TabBar.Translucent = false;
        base.SetAppearance(controller, appearance);
    }
}