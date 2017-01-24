using EI.Web.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EI.Web.Infrastructure.Validators
{
    public class FreeDownloadViewModelValidator : AbstractValidator<FreeDownloadViewModel>
    {
        public FreeDownloadViewModelValidator()
        {
            RuleFor(e => e.Name).NotEmpty().Length(1, 100)
                    .WithMessage("Please enter a Name");

            RuleFor(e => e.Description).NotEmpty().Length(1, 1000)
                   .WithMessage("Please enter a Description");

            RuleFor(e => e.DateSubmitted).NotEmpty()
                   .WithMessage("Please enter Submitted Date");
        }
    }
}