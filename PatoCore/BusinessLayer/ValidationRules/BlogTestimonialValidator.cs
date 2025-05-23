﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class BlogTestimonialValidator : AbstractValidator<BlogTestimonials>
	{
		public BlogTestimonialValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş geçilemez");
			RuleFor(x => x.Mail).NotEmpty().WithMessage("Bu alan boş geçilemez");
			RuleFor(x => x.Comment).NotEmpty().WithMessage("Bu alan boş geçilemez");
		}
	}
}
