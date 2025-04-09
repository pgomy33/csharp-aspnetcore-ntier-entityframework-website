using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Concrete.ViewModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete.ViewModels;

namespace FirstCodee.Controllers
{
    public class AdminRepeat3Controller : Controller
    {
       Repeat3Manager _manager = new Repeat3Manager(new EFRepeat3Dal());
       MenuCategoryManager _cmanager = new MenuCategoryManager(new EFMenuCategoryDal());
        public IActionResult Index()
        {
            var values = _manager.TGetlist();
            return View(values);
        }
        [HttpGet]
        public IActionResult addRepeat()
        {
            var mcategory = _cmanager.TGetlist();
            var viewModel = new MenuItemViewModel
            {
                Categories = mcategory,
                menuItem = new Repeat3()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult addRepeat(MenuItemViewModel p)
        {
            Repeat3Validator rv = new Repeat3Validator();
            ValidationResult result = rv.Validate(p.menuItem);
            if (result.IsValid)
            {
                if (p.menuItem.Image != null)
                {
                    var extension = Path.GetExtension(p.menuItem.Image.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", newImageName);

                    using (var stream = new FileStream(location, FileMode.Create))
                    {
                        p.menuItem.Image.CopyTo(stream);
                    }

                    p.menuItem.Repeat3Image = newImageName;
                }
                else
                    p.menuItem.Repeat3Image = "Resim Yüklenmemiş";
                p.menuItem.State = true;
                _manager.TAdd(p.menuItem);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View("addRepeat", p);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult editRepeat(int id)
        {
            var value = _manager.TGetById(id);
            var categories = _cmanager.TGetlist();
            var viewModel = new MenuItemViewModel{
                menuItem = value,
                Categories = categories
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult editRepeat(MenuItemViewModel p)
        {
            Repeat3Validator rv = new Repeat3Validator();
            ValidationResult result = rv.Validate(p.menuItem);
            if (result.IsValid)
            {
                if (p.menuItem.Image != null)
                {
                    var extension = Path.GetExtension(p.menuItem.Image.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", newImageName);

                    using (var stream = new FileStream(location, FileMode.Create))
                    {
                        p.menuItem.Image.CopyTo(stream);
                    }

                    p.menuItem.Repeat3Image = newImageName;
                }
                _manager.TUpdate(p.menuItem);
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
