using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.Controllers
{
    public class AdminRHourController : Controller
    {
        RhoursManager _manager = new RhoursManager(new EFRHoursDal());
        public IActionResult Index()
        {
            var values = _manager.TGetlist();
            return View(values);
        }
        [HttpGet]
        public IActionResult addRHour()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addRHour(RHours p)
        {
            RHoursValidator rv = new RHoursValidator();
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
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
                return View("addRHour", p);
            }
        }
        [HttpGet]
        public IActionResult updateRHour(int id)
        {
            var value = _manager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult updateRHour(RHours p)
        {
            RHoursValidator rv = new RHoursValidator();
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
                return View("addRHour", p);
            }
        }

        public IActionResult deleteRHour(int id)
        {
            var value = _manager.TGetById(id);
            _manager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
