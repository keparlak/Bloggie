using Bloggie.Web.Data;
using Bloggie.Web.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web
{
    //program.cs dostas� uygulaman�n konfig�rasyon ayarlar�n�n ya��ld��� uygulaman�n ba�lad��� dosyad�r. Builder ad�nda bir middleware'imiz bulunmaktad�r. Bu middleware ile programda kullanaca��z t�m servisleri tan�mlamaktay�z. �leride kullanaca��m�z t�m ek servisleri bu alanda tan�mlayaca��z.
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

            //app. diyerek kulland���m�z request s�recindeki t�m �zellikler a�a��da tan�mlanm��t�r. ��imize yarayacak olan �zelliklerin tamam�n� da app. diyerek  tan�ml�yor olaca��z. �rne�in a�a��da app.UseAuthorization() �zelli�i request pipeline'a tan�mlanm��t�r. Bizler ise kimlik kontrol� yapmak istedi�imizde Authentication �zelli�ini kullan�yor olaca��z. Bunun i�in ileride app.UseAuthentication() isimli �zelli�i dahil edece�iz.

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