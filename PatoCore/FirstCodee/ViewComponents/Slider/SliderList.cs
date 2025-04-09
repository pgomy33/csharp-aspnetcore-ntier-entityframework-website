using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.ViewComponents.Slider
{
	public class SliderList : ViewComponent
	{
		SliderManager _manager = new SliderManager(new EFSliderDal());
		public IViewComponentResult Invoke()
		{
			var values = _manager.TGetlist();
			return View(values);
		}
	}
}
