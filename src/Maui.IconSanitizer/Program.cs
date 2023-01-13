// See https://aka.ms/new-console-template for more information

args = new[]
{
    @"/Users/mlach/Downloads/Iconly",
    "svg",
};
var dir = Directory.GetCurrentDirectory();

if (args.Length > 1)
{
    if (args[0] != ".")
    {
        dir = args[0];
    }
}

if (!Directory.Exists(dir))
{
    Console.WriteLine($"'{dir}' is not a valid directory");
    Console.WriteLine($"Usage: maui-sanitize <path> <file types...>");
    return;
}

var fileExtensionsToChange = new HashSet<string>(args.Skip(1));

SanitizeDirectory(dir, null, null);

void SanitizeDirectory(string currentDir, string prependWith, string appendWith)
{
    var files = Directory.GetFiles(currentDir);
    foreach (var file in files)
    {
        var ext = Path.GetExtension(file);
        
        if (ext.Length == 0)
        {
            continue;
        }

        if (!fileExtensionsToChange.Contains(ext.Substring(1)))
        {
            continue;
        }

        var unsanitized = Path.GetFileNameWithoutExtension(file);
        var sanitized = Sanitize(unsanitized, prependWith, appendWith);
        if (sanitized == unsanitized)
        {
            continue;
        }

        Console.WriteLine($"Sanitizing '{file}' -> {sanitized}{ext}");
        File.Move(file, Path.Combine(currentDir, sanitized + ext));
    }

    foreach (var subdir in Directory.GetDirectories(currentDir))
    {
        SanitizeDirectory(subdir, prependWith, appendWith + " " + Path.GetFileName(subdir));
    }
}

string Sanitize(string input, string prependWith, string appendWith)
{
    return (prependWith + input + appendWith)
        .ToLower()
        .Replace(" - ", "_")
        .Replace(" ", "_")
        .Replace("-", "_");
}

