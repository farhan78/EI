using EI.Web.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EI.Web.Infrastructure.Validators
{
    public class ReportViewModelValidator : AbstractValidator<ReportViewModel>
    {
        public ReportViewModelValidator()
        {
            RuleFor(e => e.Name).NotEmpty().Length(1, 100)
                    .WithMessage("Please enter a Name");

            RuleFor(e => e.Description).NotEmpty().Length(1, 1000)
                    .WithMessage("Please enter a Description");

            RuleFor(e => e.DateSubmitted).NotEmpty()
                    .WithMessage("Please enter a Date");

            RuleFor(e => e.DownloadPath).Length(1, 100)
                    .WithMessage("Download path should be 100 characters");

            RuleFor(e => e.ImageUrl).Length(1, 100)
                   .WithMessage("Image Url should be 100 characters");
        }
    }
}