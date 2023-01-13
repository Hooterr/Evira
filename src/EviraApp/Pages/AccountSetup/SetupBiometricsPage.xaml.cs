using Evira.App.PageModels.AccountSetup;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.AccountSetup;

public partial class SetupBiometricsPage : BaseContentPage<SetupBiometricsPageModel>
{
	public SetupBiometricsPage(SetupBiometricsPageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}
}
