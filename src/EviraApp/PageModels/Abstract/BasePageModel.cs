using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Evira.App.Services;

namespace Evira.App.PageModels.Abstract
{
	public abstract partial class BasePageModel : ObservableObject
    {
		[ObservableProperty]
		private string _title;

		[ObservableProperty]
		private bool _isBusy;

		protected readonly INavigationService _navigationService;
		
		protected BasePageModel()
		{
			_navigationService = IoC.Current.GetRequiredService<INavigationService>();
		}

		protected async Task ExecuteBusyAction(Func<Task> action)
		{
			try
			{
				IsBusy = true;
				await action();
			}
			finally
			{
				IsBusy = false;
			}
		}

		protected virtual bool CanGoBack()
		{
			return true;
		}
		
		[RelayCommand(CanExecute = nameof(CanGoBack))]
		protected virtual async Task GoBackAsync()
		{
			await _navigationService.PopAsync();
			//await Shell.Current.GoToAsync("../");
		}
	}
}

