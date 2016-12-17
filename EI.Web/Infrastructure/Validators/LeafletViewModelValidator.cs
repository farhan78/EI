using EI.Web.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EI.Web.Infrastructure.Validators
{
    public class LeafletViewModelValidator : AbstractValidator<LeafletViewModel>
    {
        public LeafletViewModelValidator()
        {
            RuleFor(e => e.Name).NotEmpty().Length(1, 50)
                    .WithMessage("Please enter a Name");
            RuleFor(e => e.Description).NotEmpty().Length(1, 1000)
                    .WithMessage("Please enter a Description");
            RuleFor(e => e.Price).GreaterThan(0)
                   .WithMessage("Please enter a Price");
            RuleFor(e => e.Format).NotEmpty().Length(1, 50)
             .WithMessage("Please enter a Format");
            RuleFor(e => e.DateSubmitted).NotEmpty()
             .WithMessage("Please enter Date Submitted");
            RuleFor(e => e.PostagePrice).GreaterThan(0)
                 .WithMessage("Please enter a Postage Price");
            RuleFor(e => e.Availability).NotEmpty().Length(1, 50)
           .WithMessage("Please enter Availability");
        }
    }
}