using Evira.App.PageModels.AccountSetup;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.AccountSetup;

public partial class FillProfilePage : BaseContentPage<FillProfilePageModel>
{
	public FillProfilePage(FillProfilePageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}
}
