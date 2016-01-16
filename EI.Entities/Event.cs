using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.Entities
{
    public class Event : IEntityBase
    {
        public Event()
        {

        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Venue { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ViewAs { get; set; }
        public string ViewLink { get; set; }
        public bool HasAlbum { get; set; }
        public string VideoPath { get; set; }
        public string VideoImage { get; set; }
        public string VideoDuration { get; set; }
    }
}
