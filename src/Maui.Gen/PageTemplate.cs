namespace Maui.Gen;

public class PageTemplate
{
    public static void Create(string rootNameSpace, string projPath, string localPath, string name)
    {
        var contents = File.ReadAllText("./Templates/PageTemplate.xaml.txt");

        var fileNamespaceSplit = localPath.Split("/");

        var fileNamespace = rootNameSpace + "." + string.Join(".", fileNamespaceSplit); 
        
        fileNamespaceSplit[0] = "PageModels";
        var viewModelNamespace = rootNameSpace + "." + string.Join(".", fileNamespaceSplit);
        var viewModelNamespaceName = fileNamespaceSplit.Last().ToLower();

        contents = contents
            .Replace("$ROOTNAMESPACE$", rootNameSpace)
            .Replace("$CLASS$", name)
            .Replace("$NAMESPACE$",  fileNamespace)
            .Replace("$VIEWMODELNAMESPACE$", viewModelNamespace)
            .Replace("$VIEWMODELNAMESPACENAME$", viewModelNamespaceName);

        var fullpath = Path.Combine(projPath, localPath);
        if (!Directory.Exists(fullpath))
        {
            Directory.CreateDirectory(fullpath);
        }
        
        File.WriteAllText(Path.Combine(fullpath, $"{name}.xaml"), contents);
        
        contents = File.ReadAllText("./Templates/PageTemplate.cs.txt")
            .Replace("$ROOTNAMESPACE$", rootNameSpace)
            .Replace("$CLASS$", name)
            .Replace("$NAMESPACE$",  fileNamespace)
            .Replace("$VIEWMODELNAMESPACE$", viewModelNamespace)
            .Replace("$VIEWMODELNAMESPACENAME$", viewModelNamespaceName);
        
        File.WriteAllText(Path.Combine(fullpath, $"{name}.xaml.cs"), contents);

    }

}