using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.Controllers
{
    public class AdminUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
