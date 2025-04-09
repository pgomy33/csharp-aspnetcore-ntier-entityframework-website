using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstCodee.Controllers
{
    public class GalleryController : Controller
    {
        GalleryCategoryManager _cmanager = new GalleryCategoryManager(new EFGalleryCategoryDal());
        GalleryManager _manager = new GalleryManager(new EFGalleryDal());
        Context _context = new Context();
        public IActionResult Index()
        {
            var categories = _cmanager.TGetlist();
            var galleries = _manager.TGetlist();
            var viewModel = new GalleryViewModel
            {
                Categories = categories,
                Galleries = galleries
            };
            return View(viewModel);
        }
        [HttpGet]
        public JsonResult GetImagesByCategory(int? GalleryCategoryId)
        {
            var images = _context.galleries
         .Where(x => !GalleryCategoryId.HasValue || GalleryCategoryId == 1 || x.CategoryId == GalleryCategoryId)
         .Select(x => new { galleryImage = x.GalleryImage })
         .ToList();

            return Json(images);
        }
    }


}
