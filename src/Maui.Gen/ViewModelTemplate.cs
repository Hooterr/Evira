namespace Maui.Gen;

public class ViewModelTemplate
{
    public static void Create(string rootNameSpace, string projPath, string localPath, string name)
    {
        var contents = File.ReadAllText("./Templates/ViewModel.txt");

        var fileNamespace = rootNameSpace + "." + localPath.Replace("/", ".");

        contents = contents
            .Replace("$ROOTNAMESPACE$", rootNameSpace)
            .Replace("$CLASS$", name)
            .Replace("$NAMESPACE$",  fileNamespace);

        var fullPath = Path.Combine(projPath, localPath);
        if (!Directory.Exists(fullPath))
        {
            Directory.CreateDirectory(fullPath);
        }
        
        File.WriteAllText(Path.Combine(fullPath, $"{name}.cs"), contents);
    }

}