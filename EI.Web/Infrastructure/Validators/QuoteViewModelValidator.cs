using EI.Web.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EI.Web.Infrastructure.Validators
{
    public class QuoteViewModelValidator : AbstractValidator<QuoteViewModel>
    {
        public QuoteViewModelValidator()
        {
            RuleFor(e => e.Organisation).NotEmpty().Length(1, 100)
                    .WithMessage("Please enter an Organisation");

            RuleFor(e => e.Name).NotEmpty().Length(1, 50)
                    .WithMessage("Please enter a Name");

            RuleFor(e => e.Description).NotEmpty().Length(1,4000)
                    .WithMessage("Please enter a Description");
        }
    }
}