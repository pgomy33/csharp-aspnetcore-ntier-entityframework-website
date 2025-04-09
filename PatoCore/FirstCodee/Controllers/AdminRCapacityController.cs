using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.Controllers
{
    public class AdminRCapacityController : Controller
    {
        IRCapacityManager _manager = new IRCapacityManager(new EFRCapacityDal());
        public IActionResult Index()
        {
            var values = _manager.TGetlist();
            return View(values);
        }
        [HttpGet]
        public IActionResult addRCapacity()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addRCapacity(RCapacity p)
        {
            RCapacityValidator rv = new RCapacityValidator();
            ValidationResult result = rv.Validate(p);
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
                return View("addRCapacity", p);
            }
        }
        [HttpGet]
        public IActionResult updateRCapacity(int id)
        {
            var value = _manager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult updateRCapacity(RCapacity p)
        {
            RCapacityValidator rv = new RCapacityValidator();
            ValidationResult result = rv.Validate(p);
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
                return View("updateRCapacity", p);
            }
        }

        public IActionResult deleteRCapacity(int id)
        {
            var value = _manager.TGetById(id);
            _manager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
