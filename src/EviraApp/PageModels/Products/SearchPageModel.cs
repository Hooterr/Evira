using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Evira.App.Models;
using Evira.App.PageModels.Abstract;
using Evira.App.Services;
using System.Collections.ObjectModel;

namespace Evira.App.PageModels.Products;

public partial class SearchPageModel : BasePageModel
{
    private static readonly List<RecentSearchItemModel> RecentSearchesStore = new();

    #region Private Members

    private readonly IProductService _productService;

    [ObservableProperty]
    private string _searchText;

    [ObservableProperty]
    private bool _showSearchResults;

    [ObservableProperty]
    private string _searchTerm;

    [ObservableProperty]
    private int _productsCount;

    [ObservableProperty]
    private ObservableCollection<HomeProductModel> _productResults;

    #endregion

    #region Public Properties

    public ObservableCollection<RecentSearchItemModel> RecentSearches { get; } = new(RecentSearchesStore);

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor for SearchPageModel
    /// </summary>
    public SearchPageModel(IProductService productService)
    {
        _productService = productService;
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    [RelayCommand]
    private async Task FilterTappedAsync()
    {
        await AlertHelper.ShowInfoAsync("FilterTappedAsync");
    }

    [RelayCommand]
    private void ClearAllSearches()
    {
        RecentSearches.Clear();
        RecentSearchesStore.Clear();
    }

    [RelayCommand]
    public void RemoveRecentSearch(RecentSearchItemModel item)
    {
        RecentSearches.Remove(item);
        RecentSearchesStore.Remove(item);
    }

    [RelayCommand]
    private async Task SearchAsync()
    {
        if (string.IsNullOrWhiteSpace(SearchText))
        {
            return;
        }

        RecentSearchesStore.Insert(0, new RecentSearchItemModel { Text = SearchText });
        RecentSearches.Insert(0, RecentSearchesStore.First());

        IsBusy = true;
        await Task.Delay(new Random().Next(500, 2500));
        ProductResults = new ObservableCollection<HomeProductModel>(_productService.GenerateProducts(20));
        ShowSearchResults = true;
        SearchTerm = SearchText;
        ProductsCount = new Random().Next(0, 1000000);
        IsBusy = false;
    }

    [RelayCommand]
    private async Task RecentSearchSelected(RecentSearchItemModel model)
    {
        SearchText = model.Text;
        await SearchAsync();
    }

    #endregion
}