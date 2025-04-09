using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class RHoursValidator : AbstractValidator<RHours>
    {
        public RHoursValidator() 
        {
            RuleFor(x => x.Hour).NotEmpty().WithMessage("Bu alan boş geçilemez");
        }
    }
}
