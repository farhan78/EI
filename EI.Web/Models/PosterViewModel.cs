using EI.Web.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EI.Web.Models
{
    public class PosterViewModel : IValidatableObject
    {
        public int ID { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
     
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new PosterViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}