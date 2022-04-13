using Microsoft.EntityFrameworkCore;

namespace GenericRepository.EntityFrameworkCore
{
    public class GenericDbContext : DbContext
    {
        public GenericDbContext(DbContextOptions<GenericDbContext> options)
        : base(options) { }


        public override int SaveChanges()
        {

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedDate").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedDate").IsModified = false;
                }
            }
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("LastUpdated") != null))
            {
                entry.Property("LastUpdated").CurrentValue = DateTime.Now;
            }
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Active") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Active").CurrentValue = true;
                }
            }
            return base.SaveChanges();
        }
    }
}
