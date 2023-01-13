using Evira.App.PageModels.Login;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Login;

public partial class SignInPage : BaseContentPage<SignInPageModel>
{
	public SignInPage(SignInPageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}
}
