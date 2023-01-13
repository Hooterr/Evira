// See https://aka.ms/new-console-template for more information

using CommandLine;
using Microsoft.Build.Construction;

namespace Maui.Gen;

public class Program
{
    public static void Main(string[] args)
    {
        Parser.Default.ParseArguments<CliGenerate>(args)
            .WithParsed(Run)
            .WithNotParsed(x => Console.WriteLine(x));
    }

    public static void Run(CliGenerate opts)
    {
        var files = Directory.GetFiles(opts.ProjPath, "*.csproj");

        var csproj = ProjectRootElement.Open(files.First());
        var rootNamespace = csproj.Properties.FirstOrDefault(x => x.Name == "RootNamespace").Value;
        if (!string.IsNullOrEmpty(opts.ComboName))
        {
            Parse(opts.ComboName + "PageModel", "PageModels", out var localPathVm, out var nameVm);
            Parse(opts.ComboName + "Page", "Pages", out var localPathPage, out var namePage);
            ViewModelTemplate.Create(rootNamespace, opts.ProjPath, localPathVm, nameVm);
            PageTemplate.Create(rootNamespace, opts.ProjPath, localPathPage, namePage);
        }
        
        else if (!string.IsNullOrEmpty(opts.ViewModelName))
        {
            // ProjPath ../
            // LocalPath PageModels/SubFolder, PageModels
            // Name, LoginPageModel
            Parse(opts.ViewModelName, "PageModels", out var localPath, out var name);
            
            Console.WriteLine(opts.ProjPath);
            Console.WriteLine(localPath);
            Console.WriteLine(name);
            ViewModelTemplate.Create(rootNamespace, opts.ProjPath, localPath, name);
        }
        else if (!string.IsNullOrEmpty(opts.PageName))
        {
            Parse(opts.PageName, "Pages", out var localPath, out var name);
            Console.WriteLine(opts.ProjPath);
            Console.WriteLine(localPath);
            Console.WriteLine(name);
            PageTemplate.Create(rootNamespace, opts.ProjPath, localPath, name);
        }
    }

    private static void Parse(string input, string rootFolder, out string localPath, out string name)
    {
        input = Path.Combine(rootFolder, input);

        var splitPath = input.Split("/");
        name = splitPath.Last();
        localPath = input.Substring(0, input.Length - name.Length - 1);
    }
}
