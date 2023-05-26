using System;
using Evira.App.PageModels.Abstract;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Evira.App.Pages.AccountSetup;

namespace Evira.App.PageModels.AccountSetup;

public partial class FillProfilePageModel : BasePageModel
{
    #region Private Members

    #endregion
    
    #region Public Properties

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor for FillProfilePageModel
    /// </summary>
    public FillProfilePageModel()
    {
        Title = "Fill your profile";
    }

    #endregion
    
    #region Public Methods
    
    #endregion
    
    #region Private Methods

    [RelayCommand]
    private async Task ContinueAsync()
    {
        await _navigationService.PushAsync<CreatePinPage>();
        //await Shell.Current.GoToAsync($"{nameof(CreatePinPage)}");
    }
    
    #endregion
}