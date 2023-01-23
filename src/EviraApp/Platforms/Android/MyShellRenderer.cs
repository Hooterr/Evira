using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using Evira.App.AttachedProperties;
using Google.Android.Material.BottomNavigation;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;

namespace Evira.App.Platforms;

public class MyShellRenderer : ShellRenderer
{
    public MyShellRenderer(Context context) : base(context)
    {
    }

    protected override IShellItemRenderer CreateShellItemRenderer(ShellItem shellItem)
    {
        return new MySellItemRenderer(this);
    }
}

public class MySellItemRenderer : ShellItemRenderer
{
    public MySellItemRenderer(IShellContext shellContext) : base(shellContext)
    {
    }

    protected override async void SetupMenu(IMenu menu, int maxBottomItems, ShellItem shellItem)
    {
        base.SetupMenu(menu, maxBottomItems, shellItem);
        var shellItems = ((IShellItemController)shellItem).GetItems();
        var context = ShellContext.Shell.Handler.MauiContext;
        var tasks = new List<Task>();
        for (int i = 0; i < menu.Size(); i++)
        {
            var item = menu.GetItem(i);
            var unselectedIcon = shellItems[i].Icon;
            var selectedIcon = SelectedIconProperty.GetSource(shellItems[i].CurrentItem);
            var task = SetMenuItemIcons(item, selectedIcon, unselectedIcon, context);
            tasks.Add(task);
        }

        await Task.WhenAll(tasks);
    }

    static async Task SetMenuItemIcons(IMenuItem menuItem, ImageSource selectedSource, ImageSource unselectedSource, IMauiContext context)
    {
       // if (!menuItem.IsAlive())
         //   return;

        if (selectedSource == null || unselectedSource == null)
            return;

        var services = context.Services;
        var provider = services.GetRequiredService<IImageSourceServiceProvider>();
        var selectedImageSourceService = provider.GetRequiredImageSourceService(selectedSource);
        var unselectedImageSourceService = provider.GetRequiredImageSourceService(unselectedSource);

        var selectedImageResult = await selectedImageSourceService.GetDrawableAsync(
            selectedSource,
            context.Context);

        var unselectedImageResult = await unselectedImageSourceService.GetDrawableAsync(
            unselectedSource,
            context.Context);

        var drawable = new AnimatedStateListDrawable();
       
        

        drawable.AddState(new[] { Android.Resource.Attribute.StateChecked }, selectedImageResult.Value);
        drawable.AddState(new[] { -Android.Resource.Attribute.StateChecked }, unselectedImageResult.Value);

        //menuItem.IsAlive() && 
        if (selectedImageResult is not null)
            menuItem.SetIcon(drawable);
    }
}