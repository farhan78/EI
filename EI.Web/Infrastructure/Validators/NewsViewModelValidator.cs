using EI.Web.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EI.Web.Infrastructure.Validators
{
    public class NewsViewModelValidator : AbstractValidator<NewsViewModel>
    {
        public NewsViewModelValidator()
        {
            RuleFor(e => e.Title).NotEmpty().Length(1, 100)
                    .WithMessage("Please enter a Title");

            RuleFor(e => e.Description).NotEmpty().Length(1, 1000)
                   .WithMessage("Please enter a Description");

            RuleFor(e => e.NewsDate).NotEmpty()
                   .WithMessage("Please enter a News Date");
        }
    }
}