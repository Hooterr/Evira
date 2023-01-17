using CommunityToolkit.Mvvm.ComponentModel;
using Evira.App.Enums;

namespace Evira.App.Models;

public partial class RestorePasswordMethodItemModel : ObservableObject
{
    [ObservableProperty]
    private bool _isSelected;

    public RestorePasswordMethodType Type { get; set; }

    public string Name { get; set; }

    public string Hint { get; set; }
}