using System;
using Evira.App.PageModels.Abstract;
using CommunityToolkit.Mvvm.ComponentModel;
using Evira.App.Models;

namespace Evira.App.PageModels.Home;

public partial class HomePageModel : BasePageModel
{
    #region Private Members

    #endregion
    
    #region Public Properties

    public List<HomeSpecialOfferModel> SpecialOffers { get; }

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor for HomePageModel
    /// </summary>
    public HomePageModel()
    {
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
    
    #endregion
}