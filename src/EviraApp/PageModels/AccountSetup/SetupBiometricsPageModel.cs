using System;
using Evira.App.PageModels.Abstract;
using Evira.App.Pages.Popups;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mopups.Services;

namespace Evira.App.PageModels.AccountSetup;

public partial class SetupBiometricsPageModel : BasePageModel
{
    #region Private Members

    #endregion
    
    #region Public Properties

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor for SetupBiometricsPageModel
    /// </summary>
    public SetupBiometricsPageModel()
    {
        Title = "Set Your Fingerprint";
    }

    #endregion
    
    #region Public Methods
    
    #endregion
    
    #region Private Methods

    [RelayCommand]
    private async Task ContinueAsync()
    {
        await MopupService.Instance.PushAsync(new CreatingAccountPopupPage());
        await Task.Delay(3000);
        await MopupService.Instance.PopAsync();
    }

    [RelayCommand]
    private async Task SkipAsync()
    {
        
    }
    
    #endregion
}