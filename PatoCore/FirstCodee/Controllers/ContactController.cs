using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.Controllers
{
    public class ContactController : Controller
    {
        ContactManager _manager = new ContactManager(new EFContactDal());
        AddressManager _amanager = new AddressManager(new EFAddressDal());

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Mail = _amanager.TGetById(1).Mail;
            ViewBag.Phone = _amanager.TGetById(1).Phone;
            ViewBag.Adres = _amanager.TGetById(1).Title;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact p)
        {
            ContactValidator cv = new ContactValidator();
            ValidationResult result = cv.Validate(p);
            if (result.IsValid)
            {
                _manager.TAdd(p);
                TempData["SuccessMessage"] = "Mesajınız iletildi.";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Mesajınız gönderilmedi. Lütfen ilgili alanları doldurduğunuzdan emin olun.";
                foreach (var item in result.Errors)
                {
                    Console.WriteLine($"Hata: {item.PropertyName} - {item.ErrorMessage}");
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View("Index", p);
            }
        }

    }
}
