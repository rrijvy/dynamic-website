﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alphasoft.Models;

namespace Alphasoft.IRepositories
{
    public interface IAboutUsRepository : IRepository<AboutUs>
    {
       
      
        List<AboutUs> GetWithAboutUs();
        AboutUs GetWithAbout();
    }
}
