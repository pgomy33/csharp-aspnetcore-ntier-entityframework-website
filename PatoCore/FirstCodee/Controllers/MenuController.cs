using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.Controllers
{
    public class MenuController : Controller
    {
        Repeat3Manager _manager = new Repeat3Manager(new EFRepeat3Dal());
        MenuCategoryManager _cmanager = new MenuCategoryManager(new EFMenuCategoryDal());
        public IActionResult Index()
        {
            var values = _cmanager.TGetlist();
            var rvalues = _manager.TGetlist();
            var viewModel = new MenuItemViewModel 
            {
                Categories = values,
                MenuList = rvalues,
                menuItem = new EntityLayer.Concrete.Repeat3()
            };
            return View(viewModel);
        }
    }
}
