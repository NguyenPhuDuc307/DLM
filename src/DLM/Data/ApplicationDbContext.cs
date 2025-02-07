using DLM.Data.Entities;
using DLM.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DLM.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        IEnumerable<EntityEntry> modified = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
        foreach (EntityEntry item in modified)
        {
            if (item.Entity is IDateTracking changedOrAddedItem)
            {
                if (item.State == EntityState.Added)
                {
                    changedOrAddedItem.CreatedDate = DateTime.Now;
                }
                else
                {
                    changedOrAddedItem.LastModifiedDate = DateTime.Now;
                }
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<Category>? Categories { get; set; }
    public DbSet<Course>? Courses { get; set; }
    public DbSet<Lesson>? Lessons { get; set; }

}