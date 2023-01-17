using System;
using Evira.App.PageModels.Abstract;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Evira.App.Enums;
using Evira.App.Pages.Login;

namespace Evira.App.PageModels.Login;

public partial class LoginStartPageModel : BasePageModel
{
    #region Private Members

    #endregion
    
    #region Public Properties

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor for LoginStartPageModel
    /// </summary>
    public LoginStartPageModel()
    {
    }

    #endregion
    
    #region Public Methods
    
    #endregion
    
    #region Private Methods

    [RelayCommand]
    private async Task ThirdPartySignInAsync(ThirdPartySignInProvider provider)
    {
        await AlertHelper.ShowInfoAsync($"Singing in with {provider}");
    }
    
    [RelayCommand]
    private async Task SignInWithPasswordAsync()
    {
        await Shell.Current.GoToAsync(nameof(SignInPage));
    }

    [RelayCommand]
    private async Task NavigateToSignUpAsync()
    {
        await Shell.Current.GoToAsync(nameof(SignUpPage));
    }

    #endregion
}