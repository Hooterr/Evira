using System;
using Evira.App.PageModels.Abstract;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Evira.App.PageModels.Onboarding;
public class StepModel
{
    public string Text { get; set; }
    public string Image { get; set; }
}
public partial class WalkthroughPageModel : BasePageModel
{
    #region Private Members

    [ObservableProperty, NotifyPropertyChangedFor(nameof(ButtonText))]
    private int _currentStep;

    #endregion

    #region Public Properties

    public List<StepModel> Steps { get; }

    public string ButtonText => CurrentStep + 1 == Steps.Count ? "Get started" : "Next";

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor for WalkthroughPageModel
    /// </summary>
    public WalkthroughPageModel()
    {
        CurrentStep = 0;
        Steps = new List<StepModel>
        {
            new StepModel
            {
                Text = "We provide high quality products just for you",
                Image =  "https://s3-alpha-sig.figma.com/img/e14f/1890/39d9aad9e1a7b50fa928fad73bf27baa?Expires=1674432000&Signature=iOS4ZJTg5SFTfpYREspa2-cYOUydnyvW4Weyi5mrFA7YACDyMCjtbtP6cY26YmV6Sp~k1d2zNUpOfKkZw9FV2WlXwl9T8W~wsno4r9ii9kjWZ5UYFkiFTv60O2eVq8wIb68OVtIWxMKeau4vuG4p7ivJqBbLmx7Bb7gxq1OfcinnBVSygohz6Tb0WPJZU-9Hqrqw91Lhut~k9F3f6ecihp1XVBsAai8YeyMy7HEPYTSYR~i3rZ97OO6yp7ZNN3W9-3m4XBwsKkwewGvEfPg4N7nnZO71F8vsKkZGz7HcW8R61rVDo7ZXq~AW5n5l5EKUl48Q5B~8Zn8UWU3RF85oxQ__&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4",
            },
            new StepModel
            {
                Text = "Your satisfaction is our number one priority",
                Image =  "https://s3-alpha-sig.figma.com/img/908c/4f54/51725dc0c1ed2b1e70b1b708ea24faa7?Expires=1674432000&Signature=Dg19Dr-7VPB4btpy00PIBiee4ImeRHxVcopOPKjxjxt9vCcpcIaAL4GbFv0fc9d~MzySJaUHtt7QMSsjSpbyMzq2or~IbU5dDf033ei~5HV7xDm6gIQNZkPIe4IdFuAiz6JPzsufnQmP8-haUNt1HVh4IISobeZ8FetmwH7ucMcvFuJpyrGqPXISElVGCEG~s0~RWmRYLKPegwzYq84gpuCde3FNg0YFH1LwFA17hFjAXWCh-GKmcRQ4FE70VE6T~3eA6h7w2ZK1freLLZEZicUbBKawvlDB8-ynSoMHZBhHZquhqMoJUrbcEJ~Sle~iVaZJGkbG~0dEuSBju~mJtQ__&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4",
            },
            new StepModel
            {
                Text = "Let's fulfill your daily needs with Evira right now!",
                Image =  "https://s3-alpha-sig.figma.com/img/c6e1/ec7c/bea43479a077ad40c31baeb6b239b6e1?Expires=1674432000&Signature=Wy4lcyIswEQ9E0~Va2udtFdaPdnZrkzp9KbZj2B63bhxolVaxogxZmKFdY4cKh8d2BIfK8VSiU4ISLRg-74SriEb74ySjXSkRN9GOCK-TPdb8AW3L3pNkhjjRwHDt9UIzznKy19rsjuJ0h6exvYV1u0VssM-3Thc9HiEW2b3QbSZZzOP-y5yBoPHBGzmJxntc3RBS~3hGJXYR3weGyCAaULHVoRmSVIHOqIGov7FI06ZR18Dd8GnYoNU~WRcN9RHcnkqDlaBjtf91E6lDSrMmGRxBTR5ryVk~10nwgKco~Ks4Iy1YQjU1PTu1r9bebOmT8qZ5V6txcbeuj8VGv3JmQ__&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4",
            },
        };
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    [RelayCommand]
    private async Task NextAsync()
    {
        if (CurrentStep + 1 == Steps.Count)
        {
            // todo navigate
            await _navigationService.PopAsync();
            await _navigationService.PopAsync();
            //await Shell.Current.GoToAsync("../../");
        }
        else
        {
            CurrentStep++;
        }
    }

    #endregion
}