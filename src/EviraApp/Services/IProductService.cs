using Evira.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evira.App.Services
{
    public interface IProductService
    {
        List<HomeProductModel> GenerateProducts(int count);
    }
}
