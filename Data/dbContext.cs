using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using hospitalmanagement.Entities;

namespace hospitalmanagement.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
            foreach(var e in modelBuilder.Model.GetEntityTypes())
            {
                foreach(var fk in e.GetForeignKeys())
                {
                    fk.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }
	    }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).createdOn = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).modifiedOn = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
        public DbSet<User> user { get; set; }
        public DbSet<Hospital> hospital { get; set; }
    }
}