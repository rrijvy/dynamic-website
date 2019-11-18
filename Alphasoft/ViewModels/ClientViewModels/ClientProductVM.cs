using Alphasoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alphasoft.ViewModels
{
    public class ClientProductVM
    {
        public ClientProductVM()
        {
            ProductCategories = new List<ProductCategory>();
            Products = new List<Product>();
            PopularProducts = new List<Product>();
            ClientProjects = new List<ClientProduct>();
        }
        public Company Company { get; set; }
        public Product Product { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<Product> Products { get; set; }
        public List<Product> PopularProducts { get; set; }
        public List<ClientProduct> ClientProjects { get; set; }
     
      
    }
}
