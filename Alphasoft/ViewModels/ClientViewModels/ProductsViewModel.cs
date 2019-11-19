using Alphasoft.Models;
using System.Collections.Generic;

namespace Alphasoft.ViewModels.ClientViewModels
{
    public class ProductsViewModel
    {
        public List<Product> Products { get; set; }
        public List<Product> CategoryWiseProducts { get; set; }
        public List<Product> PopularProducts { get; set; }
        public List<CategoryProduct> CategoryProducts { get; set; }
    }
}
