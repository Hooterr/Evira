using Evira.App.PageModels.Login;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Login;

public partial class ForgotPasswordCreateNewPasswordPage : BaseContentPage<ForgotPasswordCreateNewPasswordPageModel>
{
	public ForgotPasswordCreateNewPasswordPage(ForgotPasswordCreateNewPasswordPageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}
}
