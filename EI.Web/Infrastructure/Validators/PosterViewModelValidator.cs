using EI.Web.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EI.Web.Infrastructure.Validators
{
    public class PosterViewModelValidator : AbstractValidator<PosterViewModel>
    {
        public PosterViewModelValidator()
        {
            RuleFor(e => e.Category).NotEmpty().Length(1, 100)
                    .WithMessage("Please enter a Category");
        }
    }
}