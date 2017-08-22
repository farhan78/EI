using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.Entities
{
    public class Model : IEntityBase
    {
        public Model()
        {

        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
