using Mopups.Pages;

namespace Evira.App.Pages.Popups;

public partial class CreatingAccountPopupPage : PopupPage
{
	public CreatingAccountPopupPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        spinner.Animate("spinner", v => spinner.Rotation = v, 0, 359, length: 1000, repeat: () => true);
    }
}
