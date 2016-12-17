using EI.Web.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EI.Web.Models
{
    public class LeafletViewModel : IValidatableObject
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string DownloadPath { get; set; }
        public string ImageUrl { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public decimal SpecialOfferPrice { get; set; }
        public string Format { get; set; }
        public string Availability { get; set; }
        public decimal PostagePrice { get; set; }
        public string CategoryName { get; set; }

        public decimal? DiscountPercent
        {
            get
            {
                if (SpecialOfferPrice > 0)
                {
                    return 100 - Math.Round(SpecialOfferPrice / Price * 100, 0, MidpointRounding.AwayFromZero);
                }

                return null;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new LeafletViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
