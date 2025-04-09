using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FirstCodee.Controllers
{
    public class AdminAddressController : Controller
    {

        AddressManager _manager = new AddressManager(new EFAddressDal());

        [HttpGet]
        public IActionResult editAddress()
        {
            var value = _manager.TGetById(1);
            return View(value);
        }

        [HttpPost]
        public IActionResult editAddress(Address p)
        {
            AddressValidator av = new AddressValidator();
            ValidationResult result = av.Validate(p);
            if (result.IsValid)
            {
                _manager.TUpdate(p);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(p);
        }
    }
}
