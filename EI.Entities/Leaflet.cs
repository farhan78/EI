using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.Entities
{
    public class Leaflet : IEntityBase
    {
        public Leaflet()
        {

        }

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
        public virtual LeafletCategory LeafletCategory { get; set; }
    }
}
