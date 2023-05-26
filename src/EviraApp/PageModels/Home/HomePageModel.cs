using CommunityToolkit.Mvvm.Input;
using Evira.App.Models;
using Evira.App.PageModels.Abstract;
using Evira.App.Pages.Home;
using Evira.App.Pages.Login;
using Evira.App.Pages.Products;
using System.Collections.ObjectModel;

namespace Evira.App.PageModels.Home;

public partial class HomePageModel : BasePageModel
{
    #region Private Members

    private readonly Random _random = new();
    private readonly string[] _names =
    {
         "Snake Leather Bag",
         "Suga Leather Shoes",
         "Leather Casual Suit",
          "Black Leather Bag",
          "Airtight Microphone",
    };

    #endregion

    #region Public Properties

    public List<HomeSpecialOfferModel> SpecialOffers { get; }

    public List<HomeCategoryModel> Categories { get; }

    public List<CategoryFilterItemModel> CategoryFilters { get; }

    public ObservableCollection<HomeProductModel> Products { get; }

    #endregion

    #region Constructor
    private HomeProductModel GenerateProduct()
    {
        return new()
        {
            Name = _names[_random.Next(0, _names.Length)],
            Rating = _random.NextDouble() * 5.0,
            SoldCount = _random.Next(0, 10_000_000),
            Price = _random.Next(0, 10000),
            ImageSource = "banner" + _random.Next(1, 5).ToString()
        };
    }

    private List<HomeProductModel> GenerateProducts(int count)
    {
        var list = new List<HomeProductModel>(count);
        for (int i = 0; i < count; i++)
        {
            list.Add(GenerateProduct());
        }
        return list;
    }

    /// <summary>
    /// Default constructor for HomePageModel
    /// </summary>
    public HomePageModel()
    {
        Products = new ObservableCollection<HomeProductModel>(GenerateProducts(20));

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
        await _navigationService.PushAsync<NotificationsPage>();
        //await Shell.Current.GoToAsync(nameof(NotificationsPage));
    }

    [RelayCommand]
    private async Task WishlistTapAsync()
    {
        await _navigationService.PushAsync<WhishlistPage>();
        //await Shell.Current.GoToAsync(nameof(WhishlistPage));
    }

    [RelayCommand]
    private async Task SeeAllSpecialOffersAsync()
    {
        await _navigationService.PushAsync<SpecialOffersPage>();
        //await Shell.Current.GoToAsync(nameof(SpecialOffersPage));
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
        foreach (var product in GenerateProducts(20))
        {
            Products.Add(product);
        }
    }

    [RelayCommand]
    private async Task SelectProductAsync(HomeProductModel item)
    {
        await _navigationService.PushAsync<ProductsDetailsPage>();
        //await Shell.Current.GoToAsync(nameof(ProductsDetailsPage));
    }

    [RelayCommand]
    private async Task SelectFavoriteProductAsync(HomeProductModel item)
    {
        await AlertHelper.ShowInfoAsync("SelectFavoriteProductAsync: " + item.Name);
    }

    [RelayCommand]
    private async Task SearchTappedAsync()
    {
        await _navigationService.PushAsync<SearchPage>();
        //await Shell.Current.GoToAsync(nameof(SearchPage));
    }

    [RelayCommand]
    private async Task InfiniteScrollReachedAsync()
    {
        await Task.Delay(2222);
        foreach (var item in GenerateProducts(20))
        {
            Products.Add(item);
        }
    }


    #endregion
}