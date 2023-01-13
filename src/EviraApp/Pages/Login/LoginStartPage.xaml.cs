using Evira.App.PageModels.Login;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Login;

public partial class LoginStartPage : BaseContentPage<LoginStartPageModel>
{
	public LoginStartPage(LoginStartPageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}
}
