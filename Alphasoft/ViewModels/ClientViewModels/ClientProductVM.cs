using Alphasoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alphasoft.ViewModels
{
    public class ClientProductVM
    {
      
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
        public List<ClientProduct> ClientProjects { get; set; }
     
      
    }
}
