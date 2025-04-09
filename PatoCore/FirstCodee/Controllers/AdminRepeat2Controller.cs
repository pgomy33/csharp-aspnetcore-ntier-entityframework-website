using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.Controllers
{
    public class AdminRepeat2Controller : Controller
    {
        Repeat2Manager _manager = new Repeat2Manager(new EFRepeat2Dal());
        public IActionResult Index()
        {
            var values = _manager.TGetlist();
            return View(values);
        }
        [HttpGet]
        public IActionResult addRepeat()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addRepeat(Repeat2 p)
        {
            Repeat2Validator rv = new Repeat2Validator();
            ValidationResult result = rv.Validate(p);
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

                    p.Repeat2Image = newImageName;
                }
                else
                    p.Repeat2Image = "Resim Yüklenmemiş";
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
        public IActionResult editRepeat(int id)
        {
            var value = _manager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult editRepeat(Repeat2 p)
        {
            Repeat2Validator rv = new Repeat2Validator();
            ValidationResult result = rv.Validate(p);
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

                    p.Repeat2Image = newImageName;
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

        public IActionResult deleteRepeat(int id)
        {
            var value = _manager.TGetById(id);
            _manager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
