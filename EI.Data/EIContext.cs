using EI.Data.Configurations;
using EI.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.Data
{
    public class EIContext : DbContext
    {
        public EIContext()
            : base("EI")
        {
            Database.SetInitializer<EIContext>(null);
        }

        #region Entity Sets
        public IDbSet<Event> EventSet { get; set; }
        public IDbSet<Error> ErrorSet { get; set; }
        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new EventConfiguration());
        }
    }
}
