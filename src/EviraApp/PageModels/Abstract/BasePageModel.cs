using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Evira.App.PageModels.Abstract
{
	public abstract partial class BasePageModel : ObservableObject
    {
		[ObservableProperty]
		private string _title;

		public BasePageModel()
		{
		}
	}
}

