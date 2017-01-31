using System;

namespace EI.Entities
{
    public class Report : IEntityBase
    {
        public Report()
        {

        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string DownloadPath { get; set; }
        public string ImageUrl { get; set; }
    }
}
