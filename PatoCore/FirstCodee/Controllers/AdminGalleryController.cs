using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Concrete.ViewModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.Controllers
{
    public class AdminGalleryController : Controller
    {
        GalleryManager _manager = new GalleryManager(new EFGalleryDal());
        GalleryCategoryManager _cm = new GalleryCategoryManager(new EFGalleryCategoryDal());
        public IActionResult Index()
        {
            var value = _manager.TGetlist();
            return View(value);
        }
        [HttpGet]
        public IActionResult addGallery()
        {
            var gcategory = _cm.TGetlist();
            var viewModel = new GalleryViewModel
            {
                Categories = gcategory,
                Gallery = new Gallery()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult addGallery(GalleryViewModel model)
        {
            Gallery p = model.Gallery;
            GalleryValidator gv = new GalleryValidator();
            ValidationResult result = gv.Validate(p);
            if (result.IsValid)
            {
                if (p.Image != null)
                {
                    var extension = Path.GetExtension(p.Image.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", newImageName);

                    using (var stream = new FileStream(location, FileMode.Create))
                    {
                        p.Image.CopyTo(stream);
                    }

                    p.GalleryImage = newImageName;
                }
                else
                    p.GalleryImage = "Resim Yüklenmemiş";
                p.State = true;
                _manager.TAdd(p);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult editGallery(int id)
        {
            var value = _manager.TGetById(id);
            var gcategory = _cm.TGetlist();
            var viewModel = new GalleryViewModel
            {
                Categories = gcategory,
                Gallery = value
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult editGallery(GalleryViewModel model)
        {
            Gallery p = model.Gallery;
            GalleryValidator gv = new GalleryValidator();
            ValidationResult result = gv.Validate(p);
            if (result.IsValid)
            {
                if (p.Image != null)
                {
                    var extension = Path.GetExtension(p.Image.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", newImageName);

                    using (var stream = new FileStream(location, FileMode.Create))
                    {
                        p.Image.CopyTo(stream);
                    }

                    p.GalleryImage = newImageName;
                }
                _manager.TUpdate(p);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult deleteGallery(int id)
        {
            var value = _manager.TGetById(id);
            _manager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
