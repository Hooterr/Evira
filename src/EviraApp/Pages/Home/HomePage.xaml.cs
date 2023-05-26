using Evira.App.Enums;
using Evira.App.PageModels.Home;
using Evira.App.Pages.Abstract;
using Sharpnado.Tabs;

namespace Evira.App.Pages.Home;

public partial class HomePage : BaseContentPage<HomePageModel>
{

    public HomePage(HomePageModel pageModel) : base(pageModel)
	{
		InitializeComponent();
        var delayed = new DelayedView<HomePageView>()
        {
            BindingContext = BindingContext,
            UseActivityIndicator = true,
            DelayInMilliseconds = 200,
        };
        Content = delayed;
        delayed.LoadView();
    }
    
}
