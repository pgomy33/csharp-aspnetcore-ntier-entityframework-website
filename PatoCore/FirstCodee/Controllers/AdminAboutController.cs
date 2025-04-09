using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.Controllers
{
    public class AdminAboutController : Controller
    {
        AboutManager _aboutManager = new AboutManager(new EFAboutDal());

        [HttpGet]
        public IActionResult Index()
        {
            var value = _aboutManager.TGetById(1);
            return View(value);
        }

        [HttpPost]
        public IActionResult Index(About p)
        {
            AboutValidator av = new AboutValidator();
            ValidationResult result = av.Validate(p);
            if (result.IsValid)
            {
                if (p.Image != null)
                {
                    var extension = Path.GetExtension(p.Image.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", newImageName);

                    using (var stream = new FileStream(location, FileMode.Create))
                    {
                        p.Image.CopyTo(stream);
                    }

                    p.AboutImage = newImageName;
                }
                
                _aboutManager.TUpdate(p);// Yeni resim adı
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(p);
        }
    }
}
