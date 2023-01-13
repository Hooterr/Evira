using Evira.App.DependencyServices;

// ReSharper disable once CheckNamespace
namespace Evira.App
{
    public class SafeAreaService : ISafeAreaService
    {
        public Thickness GetSafeAreaInsets()
        {
            var scene = UIKit.UIApplication.SharedApplication.ConnectedScenes.ToArray().FirstOrDefault();
            var windowScene = (UIKit.UIWindowScene)scene;
            var safeArea = windowScene.Windows.FirstOrDefault()?.SafeAreaInsets;

            return new Thickness(safeArea.Value.Left, safeArea.Value.Top, safeArea.Value.Right, safeArea.Value.Bottom);
        }
    }
}