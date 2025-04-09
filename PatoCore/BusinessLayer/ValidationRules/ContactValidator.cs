using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator() 
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Bu alan boş geçilemez");
        }
    }
}
