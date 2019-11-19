using Alphasoft.Data;
using Alphasoft.Models;
using Alphasoft.UnitOfWork;
using Alphasoft.ViewModels;
using Alphasoft.ViewModels.ClientViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
namespace Alphasoft.Controllers
{
    public class ClientViewController : Controller
    {
        private readonly IUnitOfWork _work;
        private readonly ApplicationDbContext _context;

        public List<Faq> FaqList { get; private set; }

        public ClientViewController(IUnitOfWork work, ApplicationDbContext context)
        {
            _work = work;
            _context = context;
        }

        public IActionResult Product(int id)
        {
            ClientProductVM clientProduct = new ClientProductVM
            {
                Company = _work.Companies.FirstOrDefault(),

                Product = _work.Products.GetProductWithCategory(id),

                Products = _work.Products.GetAll().Where(x => x.Id != id).ToList(),

                ProductCategories = _work.ProductCategories.GetAll(),

                ClientProjects = _work.ClientProducts.ClientProjectsByProduct(id)
            };

            return View(clientProduct);
        }

        public IActionResult Faq()
        {

            FaqVm faqvm = new FaqVm
            {
                Faqs = _work.Faq.GetAll()

            };
            return View(faqvm);
        }

        public IActionResult Blogs()
        {
            BlogsVM blogsVM = new BlogsVM
            {
                Blogs = _work.Blogs.GetAll()
            };

            return View(blogsVM);
        }

        public IActionResult OurTeam()
        {
            OurTeamVM teamVm = new OurTeamVM
            {
                Teams = _work.OurTeams.GetAllWithDepartmentAndDesignation()
            };

            return View(teamVm);
        }

        public IActionResult TeamViewDetails(int id)
        {
            OurTeamVM teamVm = new OurTeamVM
            {
                Team = _work.OurTeams.GetWithDepartmentDesignation(id),
                Teams = _work.OurTeams.GetAllWithDepartmentAndDesignation()
            };

            teamVm.Teams = teamVm.Teams.Where(x => x.Id != id && x.DepartmentId == teamVm.Team.DepartmentId).ToList();

            return View(teamVm);
        }
        public IActionResult AboutUs()
        {
            AboutUsVm aboutUsVm = new AboutUsVm
            {
                Company = _work.Companies.FirstOrDefault(),
                aboutUs = _work.AboutUs.GetWithAboutUs(),
                about = _work.AboutUs.GetWithAbout(),
            };
            return View(aboutUsVm);
        }
        public IActionResult Products()
        {
            ProductsViewModel productsViewModel = new ProductsViewModel
            {
                Products = _work.Products.GetAllWithCategory(),
            };

            productsViewModel.PopularProducts = _work.QueryHelper.GetPopularProducts(productsViewModel.Products);
            productsViewModel.CategoryProducts = _work.QueryHelper.GetCategoryProducts(productsViewModel.Products);

            return View(productsViewModel);
        }

        public IActionResult Services()
        {
            ServiceVM serviceVM = new ServiceVM
            {
                Services = _work.Services.GetAll()
            };
            return View(serviceVM);
        }

        public IActionResult Career()
        {
            return View();
        }

        public IActionResult Section_1()
        {
            var whyChooseUs = _work.ChooseUs.GetAll();
            return PartialView("_Section1", whyChooseUs);
        }

        public IActionResult Section_2()
        {
            var ourClients = _work.Client.GetAll();
            return PartialView("_Section2", ourClients);
        }

        public IActionResult Section_3()
        {
            var popularProducts = _work.Products.GetAllWithCategory();
            return PartialView("_Section3", popularProducts);
        }

        public IActionResult Section_4()
        {
            var hostingPlans = _work.HostingPlan.GetAll();
            return PartialView("_Section4", hostingPlans);
        }


        public IActionResult Section_5()
        {
            var ourProducts = _work.Products.GetAll();
            return PartialView("_Section5", ourProducts);
        }

        public IActionResult Section_6()
        {
            return PartialView("_Section6");
        }

        public IActionResult Section_7()
        {
            return PartialView("_Section7");
        }

        public IActionResult CategoryProducts(int id)
        {
            var products = _work.Products.GetCategoryWiseProducts(id);
            return PartialView("_CategoryWiseProducts", products);
        }

        public IActionResult CategoryWiseProduct(int id)
        {
            ProductsViewModel productsViewModel = new ProductsViewModel
            {
                Products = _work.Products.GetAllWithCategory(),
                CategoryWiseProducts = _work.Products.GetCategoryWiseProducts(id)
            };

            productsViewModel.PopularProducts = _work.QueryHelper.GetPopularProducts(productsViewModel.Products);
            productsViewModel.CategoryProducts = _work.QueryHelper.GetCategoryProducts(productsViewModel.Products);

            return View(productsViewModel);
        }
    }
}