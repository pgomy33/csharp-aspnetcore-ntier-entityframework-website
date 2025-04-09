using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.Controllers
{
    public class AdminSliderController : Controller
    {
        SliderManager _manager = new SliderManager(new EFSliderDal());
        public IActionResult Index()
        {
            var values = _manager.TGetlist();
            return View(values);
        }
        [HttpGet]
        public IActionResult addSlider()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addSlider(Slider p)
        {
            SliderValidator sv = new SliderValidator();
            ValidationResult result = sv.Validate(p);
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

                    p.SliderImage = newImageName;
                }
                else
                    p.SliderImage = "Resim Yüklenmemiş";
                p.State = true;
                _manager.TAdd(p);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult editSlider(int id)
        {
            var value = _manager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult editSlider(Slider p)
        {
            SliderValidator sv = new SliderValidator();
            ValidationResult result = sv.Validate(p);
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

                    p.SliderImage = newImageName;
                }
                _manager.TUpdate(p);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult deleteSlider(int id)
        {
            var value = _manager.TGetById(id);
            _manager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
