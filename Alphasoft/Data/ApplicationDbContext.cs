using Alphasoft.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Alphasoft.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<SubMenu> SubMenus { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<OurTeam> OurTeams { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ChooseUs> ChooseUs { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<ClientProduct>ClientProducts { get; set; }
        public DbSet<AboutUs>AboutUs { get; set; }
        public DbSet<HostingPlan> HostingPlan { get; set; }
        public DbSet<CustomerRivew> CustomerRivew { get; set; }

    }
}
