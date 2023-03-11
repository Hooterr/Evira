using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Evira.App.Models;
using Evira.App.PageModels.Abstract;
using System.Collections.ObjectModel;

namespace Evira.App.PageModels.Products;

public partial class SearchPageModel : BasePageModel
{
    private static readonly List<RecentSearchItemModel> _recentSearches = new List<RecentSearchItemModel>();
    #region Private Members

    [ObservableProperty]
    private string _searchText;

    #endregion

    #region Public Properties

    public ObservableCollection<RecentSearchItemModel> RecentSearches { get; } 
        = new ObservableCollection<RecentSearchItemModel>(_recentSearches);

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor for SearchPageModel
    /// </summary>
    public SearchPageModel()
    {
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    [RelayCommand]
    public async Task FilterTappedAsync()
    {
        await AlertHelper.ShowInfoAsync("FilterTappedAsync");
    }

    [RelayCommand]
    public void RemoveRecentSearch(RecentSearchItemModel item)
    {
        RecentSearches.Remove(item);
        _recentSearches.Remove(item);
    }

    [RelayCommand]
    public async Task SearchAsync()
    {
        if (string.IsNullOrWhiteSpace(SearchText))
        {
            return;
        }

        _recentSearches.Insert(0, new RecentSearchItemModel { Text = SearchText });
        RecentSearches.Insert(0, _recentSearches.First());
    }

    #endregion
}