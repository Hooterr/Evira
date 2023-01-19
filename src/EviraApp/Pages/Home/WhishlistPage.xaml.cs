using Evira.App.PageModels.Home;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Home;

public partial class WhishlistPage : BaseContentPage<WhishlistPageModel>
{
	public WhishlistPage(WhishlistPageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}
}
