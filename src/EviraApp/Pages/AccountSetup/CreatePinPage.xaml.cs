using Evira.App.PageModels.AccountSetup;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.AccountSetup;

public partial class CreatePinPage : BaseContentPage<CreatePinPageModel>
{
	public CreatePinPage(CreatePinPageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}
}
