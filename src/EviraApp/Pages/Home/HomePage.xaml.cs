using Evira.App.PageModels.Home;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Home;

public partial class HomePage : BaseContentPage<HomePageModel>
{
	public HomePage(HomePageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}
}
