using CommunityToolkit.Mvvm.Input;
using Evira.App.Models;
using Evira.App.PageModels.Abstract;
using Evira.App.Pages.Home;
using Evira.App.Pages.Login;
using Evira.App.Pages.Products;
using Evira.App.Services;
using System.Collections.ObjectModel;

namespace Evira.App.PageModels.Home;

public partial class HomePageModel : BasePageModel
{
    #region Private Members

    private readonly IProductService _productService;

    #endregion

    #region Public Properties

    public List<HomeSpecialOfferModel> SpecialOffers { get; }

    public List<HomeCategoryModel> Categories { get; }

    public List<CategoryFilterItemModel> CategoryFilters { get; }

    public ObservableCollection<HomeProductModel> Products { get; }

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor for HomePageModel
    /// </summary>
    public HomePageModel(IProductService productService)
    {
        _productService = productService;
        Products = new ObservableCollection<HomeProductModel>(_productService.GenerateProducts(20));

        Categories = new List<HomeCategoryModel>
        {
            new()
            {
                Name = "Clothes",
                Icon = "clothes",
            },
            new()
            {
                Name = "Shoes",
                Icon = "shoes",
            },
            new()
            {
                Name = "Bags",
                Icon = "bag_bold",
            },
            new()
            {
                Name = "Electronics",
                Icon = "electronics",
            },
            new()
            {
                Name = "Watch",
                Icon = "watch",
            },
            new()
            {
                Name = "Jewelry",
                Icon = "jewelry",
            },
            new()
            {
                Name = "Kitchen",
                Icon = "kitchen",
            },
            new()
            {
                Name = "Toys",
                Icon = "toys",
            }

        };

        CategoryFilters = new List<CategoryFilterItemModel>
        {
            new()
            {
                Name = "All",
                IsSelected = true,
            },
            new()
            {
                Name = "Clothes",
            },
            new()
            {
                Name = "Shoes",
            },
            new()
            {
                Name = "Bags",
            },
            new()
            {
                Name = "Electronics",
            },
            new()
            {
                Name = "Watch",
            },
            new()
            {
                Name = "Jewelry",
            },
            new()
            {
                Name = "Kitchen",
            },
            new()
            {
                Name = "Toys",
            }
        };
        SpecialOffers = new List<HomeSpecialOfferModel>
        {
            new HomeSpecialOfferModel
            {
                Title = "30%",
                SubTitle = "Today's Special",
                Content = "Get discount for every\r\norder, only valid for today",
                Image = "banner1",
            },
            new HomeSpecialOfferModel
            {
                Title = "25%",
                SubTitle = "Weekends Deals",
                Content = "Get discount for every\r\norder, only valid for today",
                Image = "banner2",
            },
            new HomeSpecialOfferModel
            {
                Title = "40%",
                SubTitle = "New Arrivals",
                Content = "Get discount for every\r\norder, only valid for today",
                Image = "banner3",
            },
            new HomeSpecialOfferModel
            {
                Title = "20%",
                SubTitle = "Black Friday",
                Content = "Get discount for every\r\norder, only valid for today",
                Image = "banner4",
            },
        };
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    [RelayCommand]
    private async Task NotificationsTappedAsync()
    {
        await Shell.Current.GoToAsync(nameof(NotificationsPage));
    }

    [RelayCommand]
    private async Task WishlistTapAsync()
    {
        await Shell.Current.GoToAsync(nameof(WhishlistPage));
    }

    [RelayCommand]
    private async Task SeeAllSpecialOffersAsync()
    {
        await Shell.Current.GoToAsync(nameof(SpecialOffersPage));
    }

    [RelayCommand]
    private async Task SelectSpecialOfferAsync(HomeSpecialOfferModel item)
    {
        await AlertHelper.ShowInfoAsync("SelectSpecialOfferAsync: " + item.Title);
    }

    [RelayCommand]
    private async Task SelectCategoryAsync(HomeCategoryModel item)
    {
        await AlertHelper.ShowInfoAsync("SelectCategoryAsync: " + item.Name);
    }

    [RelayCommand]
    private async Task SelectCategoryFilterAsync(CategoryFilterItemModel item)
    {
        var selected = CategoryFilters.FirstOrDefault(x => x.IsSelected);
        if (selected is not null)
        {
            selected.IsSelected = false;
        }
        item.IsSelected = true;
        Products.Clear();
        await Task.Delay(2222);
        foreach (var product in _productService.GenerateProducts(20))
        {
            Products.Add(product);
        }
    }

    [RelayCommand]
    private async Task SelectProductAsync(HomeProductModel item)
    {
        await Shell.Current.GoToAsync(nameof(ProductsDetailsPage));
    }

    [RelayCommand]
    private async Task SelectFavoriteProductAsync(HomeProductModel item)
    {
        await AlertHelper.ShowInfoAsync("SelectFavoriteProductAsync: " + item.Name);
    }

    [RelayCommand]
    private async Task SearchTappedAsync()
    {
        await Shell.Current.GoToAsync(nameof(SearchPage));
    }

    [RelayCommand]
    private async Task InfiniteScrollReachedAsync()
    {
        await Task.Delay(2222);
        foreach (var item in _productService.GenerateProducts(20))
        {
            Products.Add(item);
        }
    }


    #endregion
}