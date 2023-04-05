using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        //Yapmış olduğumuz MVC routing şekli yandaki gibi olacaktır: http://localhost:1544/AdminTags/Add
        public IActionResult Add()
        {
            return View();
        }
    }
}