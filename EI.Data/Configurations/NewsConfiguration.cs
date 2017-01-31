using EI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.Data.Configurations
{
    public class NewsConfiguration : EntityBaseConfiguration<News>
    {
        public NewsConfiguration()
        {
            Property(g => g.Title).IsRequired().HasMaxLength(100);
            Property(g => g.Description).IsRequired().HasMaxLength(1000);
            Property(g => g.ImageUrl).HasMaxLength(100);
            Property(g => g.NewsDate).IsRequired();
        }
    }
}
