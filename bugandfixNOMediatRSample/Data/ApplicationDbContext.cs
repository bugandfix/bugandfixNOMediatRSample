using bugandfixNOMediatRSample.Entities;
using Microsoft.EntityFrameworkCore;

namespace bugandfixNOMediatRSample.Data;


public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(builder =>
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);            
        });
    }
}
