using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly ITagInterface tagRepository;

        //private readonly BloggieDbContext bloggieDbContext;

        //DbContext için dependency injetion işlemi gerçekleştirildi.
        public AdminTagsController(ITagInterface tagRepository)
        {
            this.tagRepository = tagRepository;
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
        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,
            }; 
            await tagRepository.AddAsync(tag);

            //Submit işlemi gerçekleştikten sonra bizi Add.cshtml'de tutmasını istiyoruz.
            return RedirectToAction("List");
        }

        //Tagleri Listeleme
        [HttpGet]
        public async Task<IActionResult> List()
        {
            //use dbcontext to read tags (tagleri okuyabilmek adına dbcontextimiz ile ilişki kurduk) Akabinde bu tagleri ait olan view sayfamıza yolladık. (ListTags.cshtml)
            var tags = await tagRepository.GetAllAsync();
            return View(tags);
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid id)
        {
            //First Method
            //var tag = bloggieDbContext.Tags.Find(id);

            //Second Method
            var tag = await tagRepository.GetASync(id);

            if (tag != null)
            {
                var editTagRequest = new EditTagRequest { Id = tag.Id, Name = tag.Name, DisplayName = tag.DisplayName };

                return View(editTagRequest);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };
            var updatedTag = await tagRepository.UpdateAsync(tag);
            if (updatedTag != null)
            {
                return RedirectToAction("List");
                //Succes Notification 
            }
            else
            {
                //Error Notify
            }
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
           var deletedTag =  await tagRepository.DeleteAsync(id);
            if (deletedTag != null)
            {
            return RedirectToAction("List");
                
            }
            return View();
        }
    }
}