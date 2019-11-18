using Alphasoft.Models;
using Alphasoft.ViewModels.ClientViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alphasoft.IServices
{
    public interface IQueryHelper
    {
        List<CategoryProduct> GetCategoryProducts(List<Product> products);
    }
}
