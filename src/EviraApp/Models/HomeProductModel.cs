using CommunityToolkit.Mvvm.ComponentModel;

namespace Evira.App.Models
{
    public partial class HomeProductModel : ObservableObject
    {
        public string Name { get; set; }
        public string ImageSource { get; set; }
        public double Rating { get; set; }
        public int SoldCount { get; set; }
        public double Price { get; set; }

        [ObservableProperty]
        private bool _isFavourite;
    }
}
