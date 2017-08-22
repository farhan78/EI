using EI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.Data.Configurations
{
    public class ModelConfiguration : EntityBaseConfiguration<Model>
    {
        public ModelConfiguration()
        {
            Property(g => g.Name).IsRequired().HasMaxLength(100);
            Property(g => g.Description).HasMaxLength(200);
        }
    }
}
