using System;
using Evira.App.PageModels.Abstract;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Evira.App.Enums;
using Evira.App.Pages.AccountSetup;
using Evira.App.Pages.Login;

namespace Evira.App.PageModels.Login;

public partial class SignUpPageModel : BasePageModel
{
    #region Private Members


    [ObservableProperty, NotifyPropertyChangedFor(nameof(SignUpButtonEnabled))]
    private string _email;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(SignUpButtonEnabled))]
    private string _password;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(SignUpButtonEnabled))]
    private string _repeatPassword;
    
    #endregion
    
    #region Public Properties

    public bool SignUpButtonEnabled => !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password) &&
                                       !string.IsNullOrEmpty(RepeatPassword);
    
    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor for SignUpPageModel
    /// </summary>
    public SignUpPageModel()
    {
    }

    #endregion
    
    #region Public Methods
    
    #endregion
    
    #region Private Methods

    [RelayCommand]
    private async Task SignUpWithThirdPartyProviderAsync(ThirdPartySignInProvider provider)
    {
        await AlertHelper.ShowInfoAsync($"Singing up with {provider}");
    }
    
    [RelayCommand]
    private async Task NavigateToSignInAsync()
    {
        await _navigationService.PushAsync<SignInPage>();
        //await Shell.Current.GoToAsync($"../{nameof(SignInPage)}");
    }

    [RelayCommand]
    private async Task SignUpAsync()
    {
        await ExecuteBusyAction(async () =>
        {
            await _navigationService.PushAsync<FillProfilePage>();
            //await Shell.Current.GoToAsync($"{nameof(FillProfilePage)}");
            //await Task.Delay(3000);
        });
    }
    
    #endregion
}