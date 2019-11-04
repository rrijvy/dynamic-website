using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alphasoft.UnitOfWork;
using Alphasoft.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;
using Alphasoft.Models;

namespace Alphasoft.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IUnitOfWork _work;

        public BlogsController(IUnitOfWork work)
        {
            _work = work;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateView()
        {
            Blog blog = new Blog();

            return PartialView("_Create", blog);
        }
        public IActionResult Create(Blog blog)
        {

            if (ModelState.IsValid)
            {
                _work.Blogs.Add(blog);
                _work.Complete();
                ModelState.Clear();
                blog = new Blog();
                return PartialView("_Create", blog);
            }
           
            return PartialView("_Create", blog);
        }

        public IActionResult EditView(int id)
        {
            var blog = _work.Blogs.Get(id);
            return PartialView("_Edit", blog);
        }


        public IActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _work.Blogs.Update(blog);
                _work.Complete();
              
                return PartialView("_Edit", blog);
            }

            return PartialView("_Edit",blog);
        }

        public IActionResult Delete(int id)
        {
          
                var blog = _work.Blogs.Get(id);
                _work.Blogs.Remove(blog);
                _work.Complete();
            return Json("Delete Successfully");
        }
        public IActionResult LoadBlog()
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

            var blog = _work.Blogs.GetAll();

            var blogList = new List<BlogsViewModel>();

            //Sorting    
            if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDir))
            {
                blog = blog.AsQueryable().OrderBy(sortColumn + " " + sortColumnDir).ToList();
            }
            else
            {
                blog = blog.OrderByDescending(x => x.Id).ToList();
            }

            //Search    
            if (!string.IsNullOrEmpty(searchValue))
            {
                blog = blog.Where(x => x.Title.Contains(searchValue)).ToList();
            }

            foreach (var item in blog)
            {
                blogList.Add(new BlogsViewModel
                {
                    Id = item.Id,
                    Thumbnail=item.Thumbnail,
                    Title=item.Title,
                    Description=item.Description,

                   

                });
            }

            //total number of rows count     
            recordsTotal = blogList.Count();

            //Paging     
            var data = blogList.Skip(skip).Take(pageSize).ToList();

            //Returning Json Data    
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        }


    }
}