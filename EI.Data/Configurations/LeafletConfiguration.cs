using EI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.Data.Configurations
{
    public class LeafletConfiguration : EntityBaseConfiguration<Leaflet>
    {
        public LeafletConfiguration()
        {
            Property(g => g.Name).IsRequired().HasMaxLength(100);
            Property(g => g.Description).IsRequired().HasMaxLength(1000);
            Property(g => g.LongDescription).HasMaxLength(10000);
            Property(g => g.ImageUrl).HasMaxLength(100);
            Property(g => g.DownloadPath).HasMaxLength(100);
            Property(g => g.Price).IsRequired();
            Property(g => g.Format).IsRequired().HasMaxLength(50);
            Property(g => g.DateSubmitted).IsRequired();
            Property(g => g.Availability).IsRequired().HasMaxLength(50);
            Property(g => g.PostagePrice).IsRequired();
        }
    }
}
