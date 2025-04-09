using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Concrete.ViewModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.Controllers
{
    public class AdminBlogController : Controller
    {
        BlogCategoryManager _cmanager = new BlogCategoryManager(new EFBlogCategoryDal());
        BlogManager _manager = new BlogManager(new EFBlogDal());

        public IActionResult Index()
        {
            var values = _manager.TGetlist();
            return View(values);
        }
        [HttpGet]
        public IActionResult addBlog()
        {
            var category = _cmanager.TGetlist();
            var viewModel = new BlogViewModel 
            { 
                BlogCategories = category,
                Blog = new Blog()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult addBlog(BlogViewModel viewmodel)
        {
            Blog p = viewmodel.Blog;
            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(p);
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
                    p.DateTimeWrite = DateTime.Now;
                    p.BlogImage = newImageName;
                    p.State = true;
                }
                else
                {
                    p.State = true;
                    p.BlogImage = "Resim Yüklenmemiş";
                }

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
        public IActionResult editBlog(int id)
        {
            var value = _manager.TGetById(id);
            var category = _cmanager.TGetlist();
            var viewModel = new BlogViewModel
            {
                BlogCategories = category,
                Blog = value
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult editBlog(BlogViewModel viewmodel)
        {
            Blog p = viewmodel.Blog;
            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(p);
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

                    p.BlogImage = newImageName;
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
        public IActionResult deleteBlog(int id)
        {
            var value = _manager.TGetById(id);
            _manager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
