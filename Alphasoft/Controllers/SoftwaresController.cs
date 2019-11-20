using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Alphasoft.Controllers
{
    public class SoftwaresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}