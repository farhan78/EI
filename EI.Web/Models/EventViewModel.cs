using EI.Web.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EI.Web.Models
{
    public class EventViewModel : IValidatableObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Venue { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ViewAs { get; set; }
        public string ViewLink { get; set; }
        public bool HasAlbum { get; set; }
        public string VideoPath { get; set; }
        public string VideoImage { get; set; }
        public string VideoDuration { get; set; }

        public string StartDateString
        {
            get
            {
                return StartDate.ToString("dd MMMM yyyy");
            }
        }

        public string EndDateString
        {
            get
            {
                return EndDate.ToString("dd MMMM yyyy");
            }
        }

        public string EventPeriod
        {
            get
            {
                if (EndDate < DateTime.Now)
                {
                    return "Completed";
                }
                else if (EndDate >= DateTime.Now && StartDate <=DateTime.Now)
                {
                    return "Ongoing";
                }
                else
                {
                    return "Forthcoming";
                }
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new EventViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}