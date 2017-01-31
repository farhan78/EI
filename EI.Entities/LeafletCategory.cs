using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.Entities
{
    public class LeafletCategory : IEntityBase
    {
        public LeafletCategory()
        {

        }

        public int ID { get; set; }
        public string Category { get; set; }
        public virtual ICollection<Leaflet> Leaflets { get; set; }
    }
}
