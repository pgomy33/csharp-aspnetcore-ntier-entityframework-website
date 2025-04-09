using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.Controllers
{
    public class AdminBlogCategoryController : Controller
    {
        BlogCategoryManager _manager = new BlogCategoryManager(new EFBlogCategoryDal());
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
        public IActionResult add(BlogCategory p)
        {
            BlogCategoryValidator bcv = new BlogCategoryValidator();
            ValidationResult result = bcv.Validate(p);
            if(result.IsValid)
            {
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
        public IActionResult update(int id)
        {
            var value = _manager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult update(BlogCategory p)
        {
            BlogCategoryValidator bcv = new BlogCategoryValidator();
            ValidationResult result = bcv.Validate(p);
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

        public IActionResult delete(int id)
        {
            var value = _manager.TGetById(id);
            _manager.TDelete(value);
            return RedirectToAction("Index");
        }

        
    }
}
