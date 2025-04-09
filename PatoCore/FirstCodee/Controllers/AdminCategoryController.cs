using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManger _manager = new CategoryManger(new EFCategoryDal());
        public IActionResult Index()
        {
            var values = _manager.TGetlist();
            return View(values);
        }
        [HttpGet]
        public IActionResult addCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addCategory(Category p)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult result = cv.Validate(p);
            if (result.IsValid)
            {
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
        public IActionResult editCategory(int id)
        {
            var value = _manager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult editCategory(Category p)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult result = cv.Validate(p);
            if (result.IsValid)
            {
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

        public IActionResult deleteCategory(int id)
        {
            var value = _manager.TGetById(id);
            _manager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
