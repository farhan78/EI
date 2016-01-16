using EI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.Data.Configurations
{
    public class EventConfiguration : EntityBaseConfiguration<Event>
    {
        public EventConfiguration()
        {
            Property(g => g.Name).IsRequired().HasMaxLength(100);
            Property(g => g.Venue).HasMaxLength(100);
            Property(g => g.Description).HasMaxLength(1000);
            Property(g => g.StartDate).IsRequired();
            Property(g => g.EndDate).IsRequired();
            Property(g => g.ViewAs).HasMaxLength(50);
            Property(g => g.ViewLink).HasMaxLength(100);
            Property(g => g.HasAlbum).IsRequired();
            Property(g => g.VideoPath).HasMaxLength(100);
            Property(g => g.VideoImage).HasMaxLength(100);
            Property(g => g.VideoDuration).HasMaxLength(50);
        }
    }
}
