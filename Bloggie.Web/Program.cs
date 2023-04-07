using Bloggie.Web.Data;
using Bloggie.Web.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web
{
    //program.cs dostasý uygulamanýn konfigürasyon ayarlarýnýn yaðýldýðý uygulamanýn baþladýðý dosyadýr. Builder adýnda bir middleware'imiz bulunmaktadýr. Bu middleware ile programda kullanacaðýz tüm servisleri tanýmlamaktayýz. Ýleride kullanacaðýmýz tüm ek servisleri bu alanda tanýmlayacaðýz.
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

            //app. diyerek kullandýðýmýz request sürecindeki tüm özellikler aþaðýda tanýmlanmýþtýr. Ýþimize yarayacak olan özelliklerin tamamýný da app. diyerek  tanýmlýyor olacaðýz. Örneðin aþaðýda app.UseAuthorization() özelliði request pipeline'a tanýmlanmýþtýr. Bizler ise kimlik kontrolü yapmak istediðimizde Authentication özelliðini kullanýyor olacaðýz. Bunun için ileride app.UseAuthentication() isimli özelliði dahil edeceðiz.

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