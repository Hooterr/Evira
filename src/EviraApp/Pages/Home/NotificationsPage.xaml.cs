using Evira.App.PageModels.Home;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Home;

public partial class NotificationsPage : BaseContentPage<NotificationsPageModel>
{
	public NotificationsPage(NotificationsPageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}
}
