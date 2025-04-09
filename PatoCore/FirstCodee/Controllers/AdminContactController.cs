using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.Controllers
{
    public class AdminContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
