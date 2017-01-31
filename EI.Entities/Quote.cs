using System;

namespace EI.Entities
{
    public class Quote : IEntityBase
    {
        public Quote()
        {

        }

        public int ID { get; set; }
        public string Organisation { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public string SDescription { get; set; }
        public DateTime DateSubmitted { get; set; }
    }
}
