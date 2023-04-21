using AvaTestAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaTestAPI.Context
{
    public class MainContext : DbContext
    {
        public DbSet<Ship> Ships { get; set; }
        public DbSet<ShipObject> ShipObjects { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobHistoryRecord> JobHistoryRecords { get; set; }

        public bool IsValid { get; set; }
        public Exception Exception { get; set; }

        public MainContext(bool resetDatabase = false)
        {
            try
            {
                if (resetDatabase)
                    Database.EnsureDeleted();
                Database.EnsureCreated();
                IsValid = true;
            }
            catch (Exception e)
            {
                IsValid   = false;
                Exception = e;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var c = new DatabaseSettings();
            optionsBuilder.UseNpgsql($"Host={c.DatabaseHost};"         +
                                     $"Port={c.DatabasePort};"         +
                                     $"Database={c.DatabaseName};"     +
                                     $"Username={c.DatabaseUsername};" +
                                     $"Password={c.DatabasePassword}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShipObject>().HasOne(_ => _.ParentObject).WithMany(_ => _.Objects).HasForeignKey(_ => _.GuidParent);
            modelBuilder.Entity<ShipObject>().HasOne(_ => _.Ship).WithMany(_ => _.Objects).HasForeignKey(_ => _.GuidShip);
            modelBuilder.Entity<Job>().HasOne(_ => _.ShipObject).WithMany(_ => _.Jobs).HasForeignKey(_ => _.GuidObject);
            modelBuilder.Entity<JobHistoryRecord>().HasOne(_ => _.Job).WithMany(_ => _.JobHistoryRecords).HasForeignKey(_ => _.GuidJob);
        }
    }
}
