using Evira.App.PageModels.Orders;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Orders;

public partial class OrdersPage : BaseContentPage<OrdersPageModel>
{
	public OrdersPage(OrdersPageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}
}
