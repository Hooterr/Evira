using System;
using Evira.App.PageModels.Abstract;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Evira.App.Enums;
using Evira.App.Models;
using Evira.App.Pages.Login;

namespace Evira.App.PageModels.Login;

public partial class ForgotPasswordMethodPageModel : BasePageModel
{
    #region Private Members

    [ObservableProperty]
    private bool _isContinueEnabled;
    
    #endregion
    
    #region Public Properties

    public List<RestorePasswordMethodItemModel> Methods { get; }
    
    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor for ForgotPasswordMethodPageModel
    /// </summary>
    public ForgotPasswordMethodPageModel()
    {
        Title = "Forgot password";
        Methods = new List<RestorePasswordMethodItemModel>()
        {
            new()
            {
                Type = RestorePasswordMethodType.Sms,
                Name = "via SMS:",
                Hint = "+1 111 *******99",
            }, 
            new()
            {
                Type = RestorePasswordMethodType.Email,
                Name = "via Email:",
                Hint = "and***ley@yourdomain.com",
            }
        };
    }

    #endregion
    
    #region Public Methods
    
    #endregion
    
    #region Private Methods

    [RelayCommand]
    private void SelectMethod(RestorePasswordMethodItemModel method)
    {
        Methods.ForEach(x => x.IsSelected = false);
        method.IsSelected = true;
        IsContinueEnabled = true;
    }

    [RelayCommand(CanExecute = nameof(IsContinueEnabled))]
    private async Task ContinueAsync()
    {
        await _navigationService.PushAsync<ForgotPasswordEnterCodePage>();
        //await Shell.Current.GoToAsync($"{nameof(ForgotPasswordEnterCodePage)}");
    }
    
    #endregion
}