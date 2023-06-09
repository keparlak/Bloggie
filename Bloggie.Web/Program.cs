using Bloggie.Web.Data;
using Bloggie.Web.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web
{
    //program.cs dostası uygulamanın konfigürasyon ayarlarının yağıldığı uygulamanın başladığı dosyadır. Builder adında bir middleware'imiz bulunmaktadır. Bu middleware ile programda kullanacağız tüm servisleri tanımlamaktayız. İleride kullanacağımız tüm ek servisleri bu alanda tanımlayacağız.
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BloggieDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BloggieDbConnectionString")));

            builder.Services.AddScoped<ITagInterface, TagReposityory>(); 

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            //app. diyerek kullandığımız request sürecindeki tüm özellikler aşağıda tanımlanmıştır. İşimize yarayacak olan özelliklerin tamamını da app. diyerek  tanımlıyor olacağız. Örneğin aşağıda app.UseAuthorization() özelliği request pipeline'a tanımlanmıştır. Bizler ise kimlik kontrolü yapmak istediğimizde Authentication özelliğini kullanıyor olacağız. Bunun için ileride app.UseAuthentication() isimli özelliği dahil edeceğiz.

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //http://localhost:5050/Kitap/Index/

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}