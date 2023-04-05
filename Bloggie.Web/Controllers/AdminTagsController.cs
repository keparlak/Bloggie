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

        //Http Post metodu çalıştırıyoruz. Burada amacımız Add View'ında oluşturmuş olduğumuz form içerisinde gerçekleşen POST metodu butona tıklandığında submit olsun. Ve bu submit sonrasında aşağıdaki action'ımız devreye girsin.
        //Peki kullanıcının bu bahsi geçen view üzerinde inputlara girmiş olduğu verileri sayfamıza nasıl çekeceğiz??.
        //1. Yöntem - Bunun için önce view'a gideceğiz ve inputlara birer Name vereceğiz. Sonra da controllerın içeriinde birer değişkende formdan gelen inputları aşağıdaki gibi tutacağız.
        //Fakat get metodu kullandığımız Add action'ı ile post metodunda kullandığımız Add action'ının adları aynı olamamaktadır. Çünkü bir metot aynı sayıda parametreyi alarak yeniden aynı isimde kullanılamamaktadır. Dolayısıyla biz de metodumuzun adının farklı olmasını fakatdavranış biçiminin aynı olmasını sağlamak adına ActionName adında bir özellik kullanarak bu metodun da Add action'ı içinde davranış sergilemesini sağladık.
        [HttpPost]
        [ActionName("Add")]
        public IActionResult SubmitTag()
        {
            var name = Request.Form["name"];
            var displayName = Request.Form["displayName"];

            //Submit işlemi gerçekleştikten sonra bizi Add.cshtml'de tutmasını istiyoruz.
            return View("Add");
        }
    }
}