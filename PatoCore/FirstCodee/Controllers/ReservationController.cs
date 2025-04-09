using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Concrete.ViewModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.Controllers
{
    public class ReservationController : Controller
    {
        ReservationManager rmanager = new ReservationManager(new EFReservationDal());
        RhoursManager hmanager = new RhoursManager(new EFRHoursDal());
        IRCapacityManager cmanager = new IRCapacityManager(new EFRCapacityDal());
        [HttpGet]
        public IActionResult Index()
        {
            var capacities = cmanager.TGetlist();
            var hours = hmanager.TGetlist();
            var hcViewModel = new HourCapacityViewModel
            {
                Hours = hours,
                Capacities = capacities,
                Reservation = new Reservation()
            };
            return View(hcViewModel);
        }

        [HttpPost]
        public IActionResult Index(HourCapacityViewModel p)
        {
            ReservationValidator rv = new ReservationValidator();
            ValidationResult result = rv.Validate(p.Reservation);
            if (result.IsValid)
            {
                rmanager.TAdd(p.Reservation);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                var hcViewModel = new HourCapacityViewModel
                {
                    Hours = hmanager.TGetlist(),
                    Capacities = cmanager.TGetlist(),
                    Reservation = p.Reservation
                };
                return View("Index",hcViewModel);
            }
        }
    }
}