using Microsoft.EntityFrameworkCore;
using NYCTaxiViewer.Models;

namespace NYCTaxiViewer.Data
{
    public class TaxiContext : DbContext
    {
        public TaxiContext(DbContextOptions<TaxiContext> options) : base(options)
        {
        }

        public DbSet<TaxiTrip> TaxiTrips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxiTrip>().ToTable("TaxiTrip");
        }
    }
}
