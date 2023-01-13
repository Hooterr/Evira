using Evira.App.PageModels.Login;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Login;

public partial class ForgotPasswordMethodPage : BaseContentPage<ForgotPasswordMethodPageModel>
{
	public ForgotPasswordMethodPage(ForgotPasswordMethodPageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}
}
