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
        public IDbSet<Poster> PosterSet { get; set; }
        public IDbSet<News> NewsSet { get; set; }
        public IDbSet<Report> ReportSet { get; set; }
        public IDbSet<Book> BookSet { get; set; }
        public IDbSet<Leaflet> LeafletSet { get; set; }
        public IDbSet<LeafletCategory> LeafletCategorySet { get; set; }
        public IDbSet<FreeDownload> FreeDownloadSet { get; set; }
        public IDbSet<Quote> QuoteSet { get; set; }
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
            modelBuilder.Configurations.Add(new PosterConfiguration());
            modelBuilder.Configurations.Add(new NewsConfiguration());
            modelBuilder.Configurations.Add(new ReportConfiguration());
            modelBuilder.Configurations.Add(new BookConfiguration());
            modelBuilder.Configurations.Add(new QuoteConfiguration());
            modelBuilder.Configurations.Add(new LeafletConfiguration());
            modelBuilder.Configurations.Add(new FreeDownloadConfiguration());

            modelBuilder.Entity<LeafletCategory>()
                .HasKey(t => t.ID);

            modelBuilder.Entity<Leaflet>()
                .HasRequired(t => t.LeafletCategory)
                .WithMany(d => d.Leaflets)
                .HasForeignKey(d => d.CategoryID);


        }
    }
}
