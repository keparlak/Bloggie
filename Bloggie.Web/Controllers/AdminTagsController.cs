﻿using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly BloggieDbContext bloggieDbContext;

        //DbContext için dependency injetion işlemi gerçekleştirildi.
        public AdminTagsController(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }

        //Yapmış olduğumuz MVC routing şekli şunun gibi olacaktır.
        //htt://localhost:1544/AdminTags/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /*
         View üzerinden kullanıcının gireceği veri kadar olan kısım için bir view model oluşturduk ve orjinal domain modeldeki kullandığımız ihtiyacımız olan propertyleri içerisinde ekledik. Viewda artık bu viewmodel'a erişmek için en üst kısma bir model tanımlası yapıp viewmodelımızın bulunduğu namespace'i tanımladık. Sonra da inputlardaki değişiklikleri bu viewmodel'a aktarmak için her input'a birer "asp-for" prop'u geçitik. Bunun da amacı şuydu; sayfanın en üstünde tanımlamış olduğumuz model içindeki propertyler'den hangilerini doldurmamız gerektiğini tanımladığımız alandı. Yani kullanıcı name bölümünde bişeyler yazdığında viewmodel içinde bulunan name kısmı dolduruluyor olacaktır. Akabinde doldurulması gerekn her yer doldurulduktan sonra submit işlemi gerçekleştiğinde bu verileri viewmodel üzerinde controller'a gönderiyor olacağız.
         */

        [HttpPost]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,
            };
            bloggieDbContext.Tags.Add(tag);
            bloggieDbContext.SaveChanges();
            //Submit işlemi gerçekleştikten sonra bizi Add.cshtml'de tutmasını istiyoruz.
            return View("Add");
        }
    }
}