using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Evira.App.Controls;

namespace Evira.App.Models
{
    public partial class CategoryFilterItemModel : ObservableObject, IChipItem
    {
        [ObservableProperty]
        private bool _isSelected;

        [ObservableProperty]
        private string _name;
    }
}

