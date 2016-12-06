using EI.Web.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EI.Web.Models
{
    public class BookViewModel : IValidatableObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public decimal SpecialOfferPrice { get; set; }
        public string ImageUrl { get; set; }
        public string Format { get; set; }
        public DateTime PublishDate { get; set; }
        public string Availability { get; set; }
        public decimal PostagePrice { get; set; }
        public bool AvailableForPurchase { get; set; }
        public int Order { get; set; }

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
            var validator = new BookViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
