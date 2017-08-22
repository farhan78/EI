using EI.Web.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EI.Web.Infrastructure.Validators
{
    public class ModelViewModelValidator : AbstractValidator<ModelViewModel>
    {
        public ModelViewModelValidator()
        {
            RuleFor(e => e.Name).NotEmpty().Length(1, 100)
                    .WithMessage("Please enter a Name");
        }
    }
}