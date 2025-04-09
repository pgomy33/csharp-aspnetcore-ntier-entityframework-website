using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.Controllers
{
    public class AdminGalleryCategoryController : Controller
    {
        GalleryCategoryManager _manager = new GalleryCategoryManager(new EFGalleryCategoryDal());
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
        public IActionResult add(GalleryCategory p)
        {
            p.State = true;
            _manager.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult update(int id)
        {
            var value = _manager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult update(GalleryCategory p)
        {
            _manager.TUpdate(p);
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
