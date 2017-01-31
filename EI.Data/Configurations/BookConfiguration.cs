using EI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.Data.Configurations
{
    public class BookConfiguration : EntityBaseConfiguration<Book>
    {
        public BookConfiguration()
        {
            Property(g => g.Name).IsRequired().HasMaxLength(50);
            Property(g => g.ShortDescription).IsRequired().HasMaxLength(500);
            Property(g => g.LongDescription).HasMaxLength(10000);
            Property(g => g.Price).IsRequired();
            Property(g => g.Format).IsRequired().HasMaxLength(50);
            Property(g => g.PublishDate).IsRequired();
            Property(g => g.Availability).IsRequired().HasMaxLength(50);
            Property(g => g.PostagePrice).IsRequired();
        }
    }
}
