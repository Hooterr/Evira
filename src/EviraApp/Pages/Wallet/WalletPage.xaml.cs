using Evira.App.PageModels.Wallet;
using Evira.App.Pages.Abstract;

namespace Evira.App.Pages.Wallet;

public partial class WalletPage : BaseContentPage<WalletPageModel>
{
	public WalletPage(WalletPageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
	}
}
