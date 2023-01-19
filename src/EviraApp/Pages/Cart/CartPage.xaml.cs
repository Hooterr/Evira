using Evira.App.PageModels.Cart;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Cart;

public partial class CartPage : BaseContentPage<CartPageModel>
{
	public CartPage(CartPageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}
}
