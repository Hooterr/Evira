using Evira.App.PageModels.Products;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Products;

public partial class FilterPopupPage : BaseContentPage<FilterPopupPageModel>
{
	public FilterPopupPage(FilterPopupPageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}
}
