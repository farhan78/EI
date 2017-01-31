using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.Entities
{
    public class FreeDownload : IEntityBase
    {
        public FreeDownload()
        {

        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string DownloadPath { get; set; }
        public string ImageUrl { get; set; }
        public int? Order { get; set; }
    }
}
