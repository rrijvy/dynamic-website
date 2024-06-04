using Alphasoft.Data;
using Alphasoft.Helpers;
using Alphasoft.IServices;
using Alphasoft.Services;
using Alphasoft.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace Alphasoft
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddAuthorization(option =>
            {
                ClaimHelper claimHelper = new ClaimHelper();

                var claims = claimHelper.GetClaims();

                foreach (var item in claims)
                {
                    option.AddPolicy(item, policy => policy.RequireClaim(item));
                }
            });

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton<IEmailSender, EmailSender>();
            //builder.Services.AddTransient<SeedData>();
            builder.Services.AddTransient<IImagePath, ImagePath>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }


        //public static async Task Seeder(WebApplication app)
        //{
        //    try
        //    {
        //        using (var scope = app.Services.CreateScope())
        //        {
        //            var services = scope.ServiceProvider;
        //            var seeder = services.GetRequiredService<SeedData>();
        //            await seeder.Seed();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error applying database migrations: {ex.Message}");
        //    }
        //}
    }
}
