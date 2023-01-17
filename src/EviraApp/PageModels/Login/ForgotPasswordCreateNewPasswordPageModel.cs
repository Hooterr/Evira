using System;
using Evira.App.PageModels.Abstract;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Reflection;
using CommunityToolkit.Mvvm.Input;
using Mopups.Services;
using Evira.App.Pages.Popups;
using Evira.App.Pages.Login;

namespace Evira.App.PageModels.Login;

public partial class ForgotPasswordCreateNewPasswordPageModel : BasePageModel
{
    #region Private Members

    [ObservableProperty]
    private string _password;

    [ObservableProperty]
    private string _repeatPassword;

    #endregion
    
    #region Public Properties

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor for ForgotPasswordCreateNewPasswordPageModel
    /// </summary>
    public ForgotPasswordCreateNewPasswordPageModel()
    {
        Title = "Create new password";
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

    #endregion
}