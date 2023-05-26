using System;
using Evira.App.PageModels.Abstract;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Evira.App.Helpers;
using Evira.App.Pages.Login;

namespace Evira.App.PageModels.Login;

public partial class ForgotPasswordEnterCodePageModel : BasePageModel
{
    #region Private Members

    [ObservableProperty]
    private int _timerValue = 60;

    [ObservableProperty]
    private bool _isResendVisible;

    IDispatcherTimer _timer;

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

        _timer = Dispatcher.GetForCurrentThread().CreateTimer();
        _timer.Interval = TimeSpan.FromMilliseconds(1000);
        _timer.Tick += (s, e) =>
        {
            if (TimerValue == 0)
            {
                IsResendVisible = true;
                _timer.Stop();
                return;
            }
            TimerValue--;
        };
        _timer.Start();
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    [RelayCommand]
    private async Task VerifyAsync()
    {
        if (!CodeManager.IsVerifyButtonEnabled)
        {
            return;
        }

        _timer.Stop();
        await _navigationService.PushAsync<ForgotPasswordCreateNewPasswordPage>();
        //await Shell.Current.GoToAsync($"{nameof(ForgotPasswordCreateNewPasswordPage)}");
    }

    [RelayCommand]
    private async Task ResendAsync()
    {
        await ExecuteBusyAction(async () =>
        {
            await Task.Delay(1234);
        });

        TimerValue = 60;
        _timer.Start();
        IsResendVisible = false;
    }

    #endregion
}