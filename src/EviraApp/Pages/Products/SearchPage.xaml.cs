using Evira.App.PageModels.Products;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Products;

public partial class SearchPage : BaseContentPage<SearchPageModel>
{
	public SearchPage(SearchPageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}
}
