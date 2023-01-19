using Evira.App.PageModels.Home;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Home;

public partial class SpecialOffersPage : BaseContentPage<SpecialOffersPageModel>
{
	public SpecialOffersPage(SpecialOffersPageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}
}
