using Evira.App.PageModels.Products;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Products;

public partial class ProductsDetailsPage : BaseContentPage<ProductsDetailsPageModel>
{
	public ProductsDetailsPage(ProductsDetailsPageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}
}
