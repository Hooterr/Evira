using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Evira.App.Helpers;

public partial class VerificationCodeEntryManager : ObservableObject
{
    [ObservableProperty]
    private string _code = string.Empty;

    [ObservableProperty]
    private int _selectedPosition;

    [ObservableProperty]
    private int _codeLength = 4;

    [ObservableProperty]
    private bool _isVerifyButtonEnabled;

    private readonly List<string> _segments = new List<string>();

    public VerificationCodeEntryManager(int codeLength)
    {
        _codeLength = codeLength;
        _segments = Enumerable.Repeat<string>(" ", _codeLength).ToList();

    }

    [RelayCommand]
    private void KeyPressed(string key)
    {
        _segments[SelectedPosition] = key;
        UpdateCode();
        SelectedPosition = Math.Min(SelectedPosition + 1, CodeLength - 1);
    }

    [RelayCommand]
    private void DeletePressed()
    {
        _segments[SelectedPosition] = " ";
        UpdateCode();
        SelectedPosition = Math.Max(0, SelectedPosition - 1);
    }

    private void UpdateCode()
    {
        Code = string.Join("", _segments);
        IsVerifyButtonEnabled = !_segments.Any(x => x == " ");
    }
}
