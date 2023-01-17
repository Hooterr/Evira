using System;
using Evira.App.PageModels.Abstract;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Evira.App.Helpers;

namespace Evira.App.PageModels.Login;

public partial class ForgotPasswordEnterCodePageModel : BasePageModel
{
    #region Private Members

    [ObservableProperty]
    private int _timerValue = 60;

    [ObservableProperty]
    private bool _isResendVisible;

    IDispatcherTimer timer;

    #endregion

    #region Public Properties

    public VerificationCodeEntryManager CodeManager { get; } = new VerificationCodeEntryManager(4);

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor for ForgotPasswordEnterCodePageModel
    /// </summary>
    public ForgotPasswordEnterCodePageModel()
    {
        Title = "Forgot password";

        timer = Dispatcher.GetForCurrentThread().CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(1000);
        timer.Tick += (s, e) =>
        {
            if (TimerValue == 0)
            {
                IsResendVisible = true;
                timer.Stop();
                return;
            }
            TimerValue--;
        };
        timer.Start();
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    [RelayCommand]
    private async Task VerifyAsync()
    {
        timer.Stop();
    }

    [RelayCommand]
    private async Task ResendAsync()
    {
        TimerValue = 60;
        timer.Start();
        IsResendVisible = false;
    }

    #endregion
}