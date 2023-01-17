using System;
using Evira.App.PageModels.Abstract;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Evira.App.Enums;
using Evira.App.Pages.Login;

namespace Evira.App.PageModels.Login;

public partial class SignInPageModel : BasePageModel
{
    #region Private Members

    [ObservableProperty, NotifyPropertyChangedFor(nameof(LoginButtonEnabled))]
    private string _email;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(LoginButtonEnabled))]
    private string _password;

    [ObservableProperty]
    private bool _rememberMe;

    #endregion

    #region Public Properties

    public bool LoginButtonEnabled => !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor for SignInPageModel
    /// </summary>
    public SignInPageModel()
    {
    }

    #endregion
    
    #region Public Methods
    
    #endregion
    
    #region Private Methods

    [RelayCommand]
    private async Task NavigateToForgotPasswordAsync()
    {
        await Shell.Current.GoToAsync(nameof(ForgotPasswordMethodPage));
    }
    
    [RelayCommand]
    private async Task SignInWithThirdPartyProviderAsync(ThirdPartySignInProvider provider)
    {
        await AlertHelper.ShowInfoAsync($"Singing in with {provider}");
    }

    [RelayCommand]
    private async Task NavigateToSignUpAsync()
    {
        await Shell.Current.GoToAsync($"../{nameof(SignUpPage)}");
    }
    
    #endregion
}