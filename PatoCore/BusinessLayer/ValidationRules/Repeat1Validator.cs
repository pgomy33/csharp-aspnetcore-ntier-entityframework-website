using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class Repeat1Validator : AbstractValidator<Repeat1>
    {
        public Repeat1Validator() 
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Bu alan boş geçilemez");
        }
    }
}
