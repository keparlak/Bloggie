using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    public class AdminTagsController : Controller
    {
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
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            var name = addTagRequest.Name;
            var displayName = addTagRequest.DisplayName;
            //Submit işlemi gerçekleştikten sonra bizi Add.cshtml'de tutmasını istiyoruz.
            return View("Add");
        }
    }
}