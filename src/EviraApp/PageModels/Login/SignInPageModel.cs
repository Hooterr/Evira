using System;
using Evira.App.PageModels.Abstract;
using CommunityToolkit.Mvvm.ComponentModel;

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
    
    #endregion
}