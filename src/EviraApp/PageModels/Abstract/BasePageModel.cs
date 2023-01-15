using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Evira.App.PageModels.Abstract
{
	public abstract partial class BasePageModel : ObservableObject
    {
		[ObservableProperty]
		private string _title;

		[ObservableProperty]
		private bool _isBusy;

		protected BasePageModel()
		{
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
			await Shell.Current.GoToAsync("../");
		}
	}
}

