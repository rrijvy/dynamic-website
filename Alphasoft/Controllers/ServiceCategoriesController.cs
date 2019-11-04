using Alphasoft.Data;
using Alphasoft.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Alphasoft.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Alphasoft.UnitOfWork;

namespace Alphasoft.Controllers
{
    public class ServiceCategoriesController : Controller
    {
        private readonly IUnitOfWork _work;

        public ServiceCategoriesController(IUnitOfWork work)
        {
            _work = work;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateView()
        {
            ServiceCategory serviceCategory = new ServiceCategory();

            return PartialView("_Create", serviceCategory);
        }

        public IActionResult Create(ServiceCategory serviceCategory)
        {
            if (ModelState.IsValid)
            {
                _work.ServiceCategories.Add(serviceCategory);
                _work.Complete();

                ModelState.Clear();

                serviceCategory = new ServiceCategory();

                return PartialView("_Create", serviceCategory);
            }

            return PartialView("_Create", serviceCategory);
        }

        public IActionResult EditView(int id)
        {
            var serviceCategory = _work.ServiceCategories.Get(id);

            return PartialView("_Edit", serviceCategory);
        }

        public IActionResult Edit(ServiceCategory serviceCategory)
        {
            if (ModelState.IsValid)
            {
                _work.ServiceCategories.Update(serviceCategory);

                _work.Complete();

                return PartialView("_Edit", serviceCategory);
            }
            return PartialView("_Edit", serviceCategory);
        }

        public IActionResult Delete(int id)
        {
            var serviceCategory = _work.ServiceCategories.Get(id);

            _work.ServiceCategories.Remove(serviceCategory);

            _work.Complete();

            return Json("Deleted Successfully!");
        }

        public IActionResult LoadServiceCategories()
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

            var serviceCategories = _work.ServiceCategories.GetAll();

            var serviceCategoryList = new List<ServiceCategoriesViewModel>();

            //Sorting    
            if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDir))
            {
                serviceCategories = serviceCategories.AsQueryable().OrderBy(sortColumn + " " + sortColumnDir).ToList();
            }
            else
            {
                serviceCategories = serviceCategories.OrderByDescending(x => x.Id).ToList();
            }

            //Search    
            if (!string.IsNullOrEmpty(searchValue))
            {
                serviceCategories = serviceCategories.Where(x => x.Name.Contains(searchValue)).ToList();
            }

            foreach (var item in serviceCategories)
            {
                serviceCategoryList.Add(new ServiceCategoriesViewModel
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }

            //total number of rows count     
            recordsTotal = serviceCategoryList.Count();

            //Paging     
            var data = serviceCategoryList.Skip(skip).Take(pageSize).ToList();

            //Returning Json Data    
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        }
    }
}