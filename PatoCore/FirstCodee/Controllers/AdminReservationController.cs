using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Concrete.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstCodee.Controllers
{
    public class AdminReservationController : Controller
    {

        ReservationManager _rmanager = new ReservationManager(new EFReservationDal());
        Context _context = new Context();
        public IActionResult Index()
        {
                    var reservations = _context.reservations
             .Include(r => r.rHours) // Saat bilgisini getir
             .Include(r => r.rCapacity) // Kapasite bilgisini getir
             .ToList();

            return View(reservations);
        }
    }
}
