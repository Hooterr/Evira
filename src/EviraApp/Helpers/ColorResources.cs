namespace Evira.App.Helpers;

public static class ColorResources 
{
    public static Color Get(string name) => (Color)((App)App.Current).Colors[name];

}
