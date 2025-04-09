using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Concrete.ViewModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstCodee.Controllers
{
    public class BlogController : Controller
    {
        BlogManager _bmanager = new BlogManager(new EFBlogDal());
        BlogCategoryManager _cmanager = new BlogCategoryManager(new EFBlogCategoryDal());
        BlogTestimonialManager _btmanager = new BlogTestimonialManager(new EFBlogTestimonialDal());
        Context _context;
		//public IActionResult Index()
		//{
		//    _context = new Context();
		//    var blogvalues = _context.blogs.Include(x => x.BlogCategory).ToList();
		//    //var blogsValue = _bmanager.TGetlist();
		//    var categoryValue = _cmanager.TGetlist();
		//    BlogViewModel viewmodel = new BlogViewModel
		//    {
		//        Blogs = blogvalues,
		//        BlogCategories = categoryValue
		//    };
		//    return View(viewmodel);
		//}
		public IActionResult Index(string search, int? categoryId)
		{
			_context = new Context();
			var blogs = _context.blogs.Include(x => x.BlogCategory).AsQueryable();

			// Arama filtresi
			if (!string.IsNullOrEmpty(search))
			{
				blogs = blogs.Where(x => x.Title.Contains(search) || x.Description.Contains(search));
			}

			// Kategori filtresi
			if (categoryId.HasValue)
			{
				blogs = blogs.Where(x => x.BlogCategory.ID == categoryId.Value);
			}

			var categoryValue = _cmanager.TGetlist();

			BlogViewModel viewmodel = new BlogViewModel
			{
				Blogs = blogs.ToList(),
				BlogCategories = categoryValue
			};

			return View(viewmodel);
		}
		[HttpGet]
        public IActionResult detailsBlog(int id)
        {
			_context = new Context();
			var blogvalues = _context.blogs.Include(x => x.BlogCategory).Where(a=>a.ID == id).FirstOrDefault();
			var categoryValue = _cmanager.TGetlist();
            var testimonialValue = _context.blogTestimonials.Include(x => x.Blog).ToList();
			BlogViewModel viewmodel = new BlogViewModel
			{
				Blog = blogvalues,
				BlogCategories = categoryValue,
                BlogTestimonials = testimonialValue,
                BlogTestimonial = new BlogTestimonials()
			};
			return View(viewmodel);
		}
		[HttpPost]
		public IActionResult detailsBlog(BlogViewModel viewmodel)
		{
			BlogTestimonialValidator btv = new BlogTestimonialValidator();
			ValidationResult result = btv.Validate(viewmodel.BlogTestimonial);

			if (result.IsValid)
			{
				viewmodel.BlogTestimonial.DateTime = DateTime.Now;
				_btmanager.TAdd(viewmodel.BlogTestimonial);
				return RedirectToAction("detailsBlog", new { id = viewmodel.BlogTestimonial.BlogId });
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}

				viewmodel.Blog = _context.blogs.Include(x => x.BlogCategory).FirstOrDefault(x => x.ID == viewmodel.BlogTestimonial.BlogId);
				viewmodel.BlogCategories = _cmanager.TGetlist();
				viewmodel.BlogTestimonials = _context.blogTestimonials
													 .Where(x => x.BlogId == viewmodel.BlogTestimonial.BlogId)
													 .ToList();

				return View(viewmodel);
			}
		}
	}
}
