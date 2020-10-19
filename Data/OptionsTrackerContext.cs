using Microsoft.EntityFrameworkCore;
using OptionsTracker.Models;

namespace OptionsTracker.Data
{
    public class OptionsTrackerContext : DbContext
    {
        public OptionsTrackerContext(DbContextOptions<OptionsTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<Trade> Trades { get; set; }
        public DbSet<Market> Markets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trade>().ToTable("Trade");
            modelBuilder.Entity<Market>().ToTable("Market");
        }

    }
}
