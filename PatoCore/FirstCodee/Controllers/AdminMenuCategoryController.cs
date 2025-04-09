using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.Controllers
{
    public class AdminMenuCategoryController : Controller
    {
        MenuCategoryManager _manager = new MenuCategoryManager(new EFMenuCategoryDal());
        
        public IActionResult Index()
        {
            var values = _manager.TGetlist();
            return View(values);
        }
        [HttpGet]
        public IActionResult add()
        {
            return View();
        }
        [HttpPost]

        public IActionResult add(MenuCategory p)
        {
            MenuCategoryValidator mv = new MenuCategoryValidator();
            ValidationResult result = mv.Validate(p);
            if (result.IsValid)
            {
                p.State = true;
                _manager.TAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return RedirectToAction("Index", p);
            }

            
        }

        public IActionResult update(int id)
        {
            var value = _manager.TGetById(id);
            return View(value);
        }

        public IActionResult update(MenuCategory p)
        {
            MenuCategoryValidator mv = new MenuCategoryValidator();
            ValidationResult result = mv.Validate(p);
            if (result.IsValid)
            {
                _manager.TUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return RedirectToAction("Index", p);
            }
        }

        public IActionResult delete(int id)
        {
            var value = _manager.TGetById(id);
            _manager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
