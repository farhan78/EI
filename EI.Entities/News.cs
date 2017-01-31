using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.Entities
{
    public class News : IEntityBase
    {
        public News()
        {

        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string LongDescription { get; set; }
        public DateTime NewsDate { get; set; }
    }
}
