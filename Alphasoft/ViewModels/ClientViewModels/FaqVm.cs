using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alphasoft.Models;

namespace Alphasoft.ViewModels
{
    public class FaqVm
    {
        public Faq Faq { get; set; }
        public List<Faq> Faqs { get; set; }
    }
}
