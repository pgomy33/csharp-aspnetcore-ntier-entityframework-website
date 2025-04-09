using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SSSValidator : AbstractValidator<SSS>
    {
        public SSSValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Bu alan boş geçilemez");
        }
    }
}
