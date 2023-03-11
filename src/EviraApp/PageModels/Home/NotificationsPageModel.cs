using System;
using Evira.App.PageModels.Abstract;
using CommunityToolkit.Mvvm.ComponentModel;
using Evira.App.Models;
using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.Input;

namespace Evira.App.PageModels.Home;

public partial class NotificationsPageModel : BasePageModel
{
    #region Private Members

    #endregion
    
    #region Public Properties

    public ObservableGroupedCollection<string, NotificationModel> Notifications { get; }

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor for NotificationsPageModel
    /// </summary>
    public NotificationsPageModel()
    {
        Title = "Notifications";

        var collection = new ObservableGroupedCollection<string, NotificationModel>
        {
            new ObservableGroup<string, NotificationModel>("Today", new List<NotificationModel>
            {
                new NotificationModel
                {
                    Icon = "discount_bold",
                    Title = "30% Special Discount!",
                    SubTitle = "Special promotion only valid today"
                }
            }),
            new ObservableGroup<string, NotificationModel>("Yesterday", new List<NotificationModel>
            {
                new NotificationModel
                {
                    Icon = "wallet_bold",
                    Title = "Top Up E-Wallet Successful!",
                    SubTitle = "You have to top up your e-wallet"
                },
                new NotificationModel
                {
                    Icon = "location_bold",
                    Title = "New Services Available!",
                    SubTitle = "Now you can track orders in real time"
                }
            }),
            new ObservableGroup<string, NotificationModel>("December 22, 2024", new List<NotificationModel>
            {
                new NotificationModel
                {
                    Icon = "wallet_bold",
                    Title = "Credit Card Connected!",
                    SubTitle = "Credit Card has been linked!"
                },
                new NotificationModel
                {
                    Icon = "profile_bold",
                    Title = "Account Setup Successful!",
                    SubTitle = "Your account has been created!"
                }
            })

        };

        Notifications = collection;
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    [RelayCommand]
    private async Task NotificationTapAsync(NotificationModel item)
    {
        await AlertHelper.ShowInfoAsync($"Tapped: {item.Title}");
    }

    #endregion
}