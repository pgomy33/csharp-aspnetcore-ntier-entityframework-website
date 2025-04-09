using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.Controllers
{
    public class AboutController : Controller
    {
        AboutManager _manager = new AboutManager(new EFAboutDal());
        public IActionResult Index()
        {
            var value = _manager.TGetById(1);
            return View(value);
        }
    }
}
