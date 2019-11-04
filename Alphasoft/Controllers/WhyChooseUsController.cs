using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alphasoft.Data;
using Alphasoft.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;
using Alphasoft.Models;
using Alphasoft.UnitOfWork;

namespace Alphasoft.Controllers
{
    public class WhyChooseUsController : Controller
    {
        private readonly IUnitOfWork _work;

        public WhyChooseUsController(IUnitOfWork work)
        {
            _work = work;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateView()
        {
            ChooseUs chose = new ChooseUs();
            return PartialView("_Create", chose);
        }
        public IActionResult Create(ChooseUs choseUs)
        {
            if (ModelState.IsValid)
            {
                _work.ChooseUs.Add(choseUs);
                _work.Complete();
                ModelState.Clear();
                choseUs = new ChooseUs();
                return PartialView("_Create", choseUs);
            }
            return PartialView("_Create", choseUs);
        }

        public IActionResult EditView(int id)
        {
            var choseus =_work.ChooseUs.Get(id);
            return PartialView("_Edit",choseus);

        }
        public IActionResult Edit(ChooseUs choseUs)
        {
            if (ModelState.IsValid)
            {
                _work.ChooseUs.Update(choseUs);
                _work.Complete();
            }
            return PartialView("_Edit",choseUs);
        }
        public IActionResult Delete(int id)
        {
            var choseus =_work.ChooseUs.Get(id);
            _work.ChooseUs.Remove(choseus);
            _work.Complete();
            return Json("Delete Successfully");
        }
        public IActionResult LoadChoseUs()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var choseus = _work.ChooseUs.GetAll();

            var choseusList = new List<ChoseUsViewModel>();

            //Sorting    
            if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDir))
            {
                choseus = choseus.AsQueryable().OrderBy(sortColumn + " " + sortColumnDir).ToList();
            }
            else
            {
                choseus = choseus.OrderByDescending(x => x.Id).ToList();
            }

            //Search    
            if (!string.IsNullOrEmpty(searchValue))
            {
                choseus = choseus.Where(x => x.Title.Contains(searchValue)).ToList();
            }

            foreach (var item in choseus)
            {
                choseusList.Add(new ChoseUsViewModel
                {
                    Id = item.Id,
                    Title=item.Title,
                    ShortDescription=item.ShortDescription,
                    Description=item.Description,
                    Order=item.Order,
                    IsActive=item.IsActive,

                });
            }

            //total number of rows count     
            recordsTotal = choseusList.Count();

            //Paging     
            var data = choseusList.Skip(skip).Take(pageSize).ToList();

            //Returning Json Data    
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        }
    }
}