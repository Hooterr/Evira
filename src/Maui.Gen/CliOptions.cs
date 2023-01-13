using CommandLine;

namespace Maui.Gen;

[Verb("generate", aliases: new[] { "g" })]
public class CliGenerate
{
    [Option('P', "projPath")]
    public string ProjPath { get; set; }

    [Option('n', "projName")]
    public string ProjName { get; set; }

    [Option('v', "viewmodel")]
    public string ViewModelName { get; set; }
    
    [Option('p', "pageName")]
    public string PageName { get; set; }
    
    [Option('c', "combo")]
    public string ComboName { get; set; }
}