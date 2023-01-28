using CommunityToolkit.Mvvm.Input;
using Evira.App.Models;
using Evira.App.PageModels.Abstract;
using System.Collections.ObjectModel;

namespace Evira.App.PageModels.Home;

public partial class HomePageModel : BasePageModel
{
    #region Private Members

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
    public HomePageModel()
    {
        var random = new Random();
        Products = new ObservableCollection<HomeProductModel>(new List<HomeProductModel>
        {
            new()
            {
                Name = "Snake Leather Bag",
                Rating = random.NextDouble()*5.0,
                SoldCount = random.Next(0, 10_000_000),
                Price = random.Next(0, 10000),
                ImageSource = "banner" + random.Next(1, 5).ToString()
            },
            new()
            {
                Name = "Suga Leather Shoes",
                Rating = random.NextDouble()*5.0,
                SoldCount = random.Next(0, 10_000_000),
                Price = random.Next(0, 10000),
                ImageSource = "banner" + random.Next(1, 5).ToString()
            },
            new()
            {
                Name = "Leather Casual Suit",
                Rating = random.NextDouble()*5.0,
                SoldCount = random.Next(0, 10_000_000),
                Price = random.Next(0, 10000),
                ImageSource = "banner" + random.Next(1, 5).ToString()
            },
            new()
            {
                Name = "Black Leather Bag",
                Rating = random.NextDouble()*5.0,
                SoldCount = random.Next(0, 10_000_000),
                Price = random.Next(0, 10000),
                ImageSource = "banner" + random.Next(1, 5).ToString()
            },
            new()
            {
                Name = "Airtight Microphone",
                Rating = random.NextDouble()*5.0,
                SoldCount = random.Next(0, 10_000_000),
                Price = random.Next(0, 10000),
                ImageSource = "banner" + random.Next(1, 5).ToString()
            },
            new()
            {
                Name = "Black Nike Shoes",
                Rating = random.NextDouble()*5.0,
                SoldCount = random.Next(0, 10_000_000),
                Price = random.Next(0, 10000),
                ImageSource = "banner" + random.Next(1, 5).ToString()
            },
            new()
            {
                Name = "Snake Leather Bag",
                Rating = random.NextDouble()*5.0,
                SoldCount = random.Next(0, 10_000_000),
                Price = random.Next(0, 10000),
                ImageSource = "banner" + random.Next(1, 5).ToString()
            },
            new()
            {
                Name = "Snake Leather Bag",
                Rating = random.NextDouble()*5.0,
                SoldCount = random.Next(0, 10_000_000),
                Price = random.Next(0, 10000),
                ImageSource = "banner" + random.Next(1, 5).ToString()
            },

        });

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
    private async Task SeeAllSpecialOffersAsync()
    {
        await AlertHelper.ShowInfoAsync("SeeAllSpecialOffersAsync");
    }

    [RelayCommand]
    private async Task SelectSpecialOfferAsync(HomeSpecialOfferModel item)
    {
        await AlertHelper.ShowInfoAsync("SelectSpecialOfferAsync: " + item.Title);

    }

    [RelayCommand]
    private async Task SelectCategoryAsync(HomeCategoryModel item)
    {
        await AlertHelper.ShowInfoAsync("SelectSpecialOfferAsync: " + item.Name);
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

    }

    [RelayCommand]
    private async Task SelectProductAsync(HomeProductModel item)
    {
        await AlertHelper.ShowInfoAsync("SelectProductAsync: " + item.Name);
    }

    [RelayCommand]
    private async Task SelectFavoriteProductAsync(HomeProductModel item)
    {
        await AlertHelper.ShowInfoAsync("SelectFavoriteProductAsync: " + item.Name);
    }

    #endregion
}