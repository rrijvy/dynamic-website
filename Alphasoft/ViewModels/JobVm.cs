using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alphasoft.ViewModels
{
    public class JobVm
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Qualification { get; set; }
        public string JobCreateDate { get; set; }
        public string DeadLine { get; set; }
    }
}
