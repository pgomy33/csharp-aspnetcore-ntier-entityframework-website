using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.ViewComponents.About
{
	public class AboutList : ViewComponent
	{
		AboutManager _manager = new AboutManager(new EFAboutDal());
		public IViewComponentResult Invoke()
		{
			var value = _manager.TGetById(1);
			return View(value);
		}
	}
}
