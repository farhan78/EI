using EI.Web.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EI.Web.Infrastructure.Validators
{
    public class EventViewModelValidator : AbstractValidator<EventViewModel>
    {
        public EventViewModelValidator()
        {
            RuleFor(e => e.Name).NotEmpty().Length(1,100)
                    .WithMessage("Please enter a Name");

            RuleFor(e => e.StartDate).NotEmpty()
                .WithMessage("Please enter a start date");

            RuleFor(e => e.EndDate).NotEmpty()
                       .WithMessage("Please enter an end date");

            RuleFor(e => e.StartDate).NotEmpty()
                    .WithMessage("Please enter a start date");
        }
    }
}