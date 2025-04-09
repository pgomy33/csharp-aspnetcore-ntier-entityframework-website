using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.username).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.password).NotEmpty().WithMessage("Bu alan boş geçilemez");
        }
    }
}
