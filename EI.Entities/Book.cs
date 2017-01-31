using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.Entities
{
    public class Book : IEntityBase
    {
        public Book()
        {

        }

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
    }
}
