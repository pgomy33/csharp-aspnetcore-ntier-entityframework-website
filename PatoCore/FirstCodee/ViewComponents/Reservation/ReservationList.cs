using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.ViewComponents.Reservation
{
	public class ReservationList : ViewComponent
	{
		ReservationManager rmanager = new ReservationManager(new EFReservationDal());
		RhoursManager hmanager = new RhoursManager(new EFRHoursDal());
		IRCapacityManager cmanager = new IRCapacityManager(new EFRCapacityDal());
		[HttpGet]
		public IViewComponentResult Invoke()
		{
			var capacities = cmanager.TGetlist();
			var hours = hmanager.TGetlist();
			var hcViewModel = new HourCapacityViewModel
			{ 
				Hours = hours,
				Capacities = capacities,
				Reservation = new EntityLayer.Concrete.Reservation()
			};
			return View(hcViewModel);
		}
	}
}
