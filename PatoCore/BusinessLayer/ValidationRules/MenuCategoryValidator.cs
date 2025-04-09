using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MenuCategoryValidator : AbstractValidator<MenuCategory>
    {
        public MenuCategoryValidator() 
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Desc).NotEmpty().WithMessage("Bu alan boş geçilemez");
        }
    }
}
