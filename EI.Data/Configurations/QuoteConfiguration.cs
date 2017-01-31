using EI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.Data.Configurations
{
    public class QuoteConfiguration : EntityBaseConfiguration<Quote>
    {
        public QuoteConfiguration()
        {
            Property(g => g.Organisation).IsRequired().HasMaxLength(100);
            Property(g => g.Name).IsRequired().HasMaxLength(50);
            Property(g => g.Designation).HasMaxLength(50);
            Property(g => g.Description).IsRequired().HasMaxLength(4000);
            Property(g => g.SDescription).HasMaxLength(200);
        }
    }
}
