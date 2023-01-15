using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Evira.App.PageModels.Abstract
{
	public abstract partial class BasePageModel : ObservableObject
    {
		[ObservableProperty]
		private string _title;

		protected BasePageModel()
		{
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

