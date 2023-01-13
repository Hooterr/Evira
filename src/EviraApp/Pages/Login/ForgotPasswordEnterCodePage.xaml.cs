using Evira.App.PageModels.Login;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Login;

public partial class ForgotPasswordEnterCodePage : BaseContentPage<ForgotPasswordEnterCodePageModel>
{
	public ForgotPasswordEnterCodePage(ForgotPasswordEnterCodePageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}
}
