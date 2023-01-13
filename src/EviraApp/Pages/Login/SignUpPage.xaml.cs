using Evira.App.PageModels.Login;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Login;

public partial class SignUpPage : BaseContentPage<SignUpPageModel>
{
	public SignUpPage(SignUpPageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}
}
