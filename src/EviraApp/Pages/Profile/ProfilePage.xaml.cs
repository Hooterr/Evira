using Evira.App.PageModels.Profile;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Profile;

public partial class ProfilePage : BaseContentPage<ProfilePageModel>
{
	public ProfilePage(ProfilePageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}
}
