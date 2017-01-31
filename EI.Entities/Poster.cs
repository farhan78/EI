using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.Entities
{
    public class Poster : IEntityBase
    {
        public Poster()
        {

        }

        public int ID { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
     }
}
