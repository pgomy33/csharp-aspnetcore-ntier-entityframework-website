using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class RCapacityValidator : AbstractValidator<RCapacity>
    {
        public RCapacityValidator() 
        {
            RuleFor(x => x.Capacity).NotEmpty().WithMessage("Bu alan boş geçilemez");
        }
    }
}
