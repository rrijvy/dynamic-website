using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alphasoft.Models;

namespace Alphasoft.ViewModels.ClientViewModels
{
    public class AboutUsVm
    {
        public Company Company { get; set; }
        public AboutUs about { get; set; }
        public List<AboutUs> aboutUs { get; set; }
    }
}
