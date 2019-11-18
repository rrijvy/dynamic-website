using Alphasoft.Models;
using System.Collections.Generic;

namespace Alphasoft.ViewModels.ClientViewModels
{
    public class CategoryProduct
    {
        public int ProductCategory { get; set; }
        public string ProductCategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}
