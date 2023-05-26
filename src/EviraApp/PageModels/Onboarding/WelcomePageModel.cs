using System;
using Evira.App.PageModels.Abstract;
using Evira.App.Pages.Onboarding;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Evira.App.PageModels.Onboarding;

public partial class WelcomePageModel : BasePageModel
{
    #region Private Members

    #endregion
    
    #region Public Properties

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor for WelcomePageModel
    /// </summary>
    public WelcomePageModel()
    {
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    [RelayCommand]
    private async Task NextAsync()
    {
        await _navigationService.PushAsync<WalkthroughPage>();
        //await Shell.Current.GoToAsync(nameof(WalkthroughPage));
    }
    
    #endregion
}