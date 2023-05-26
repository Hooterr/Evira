using System;
using Evira.App.PageModels.Abstract;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Evira.App.Pages.AccountSetup;
using Evira.App.Helpers;
using Evira.App.Services;

namespace Evira.App.PageModels.AccountSetup;

public partial class CreatePinPageModel : BasePageModel
{
    #region Private Members

    #endregion

    #region Public Properties

    public VerificationCodeEntryManager CodeManager { get; } = new(4);

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor for CreatePinPageModel
    /// </summary>
    public CreatePinPageModel()
    {
        Title = "Create new PIN";
    }

    #endregion
    
    #region Public Methods
    
    #endregion
    
    #region Private Methods

    [RelayCommand]
    private async Task ContinueAsync()
    {
        if (!CodeManager.IsVerifyButtonEnabled)
        {
            return;
        }

        await _navigationService.PushAsync<SetupBiometricsPage>();
        //await Shell.Current.GoToAsync($"{nameof(SetupBiometricsPage)}");
    }
    
    #endregion
}