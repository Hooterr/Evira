using Evira.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evira.App.Services
{
    public class RandomProductService : IProductService
    { 
        private static readonly Random _random = new();
        private static readonly string[] _names =
        {
                "Snake Leather Bag",
                "Suga Leather Shoes",
                "Leather Casual Suit",
                "Black Leather Bag",
                "Airtight Microphone",
        };

        private HomeProductModel GenerateProduct()
        {
            return new()
            {
                Name = _names[_random.Next(0, _names.Length)],
                Rating = _random.NextDouble() * 5.0,
                SoldCount = _random.Next(0, 10_000_000),
                Price = _random.Next(0, 10000),
                ImageSource = "banner" + _random.Next(1, 5).ToString()
            };
        }

        public List<HomeProductModel> GenerateProducts(int count)
        {
            var list = new List<HomeProductModel>(count);
            for (int i = 0; i < count; i++)
            {
                list.Add(GenerateProduct());
            }
            return list;
        }
    }
}
