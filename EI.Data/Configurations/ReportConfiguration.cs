using EI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.Data.Configurations
{
    public class ReportConfiguration : EntityBaseConfiguration<Report>
    {
        public ReportConfiguration()
        {
            Property(g => g.Name).IsRequired().HasMaxLength(100);
            Property(g => g.Description).IsRequired().HasMaxLength(1000);
            Property(g => g.DateSubmitted).IsRequired();
            Property(g => g.DownloadPath).HasMaxLength(100);
            Property(g => g.ImageUrl).HasMaxLength(100);
        }
    }
}
