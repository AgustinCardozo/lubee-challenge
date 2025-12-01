using Microsoft.EntityFrameworkCore;
using Publicacion.Domain.Entities;
using Publicacion.Infrastructure.Persistence.Configurations;
using Publicacion.Infrastructure.Persistence.EntityConfigurations;

namespace Publicacion.Infrastructure.Persistence;

public class PublicationContext(DbContextOptions options) : DbContext(options)
{
    public virtual DbSet<Publication> Publications { get; set; }
    public virtual DbSet<Image> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new PublicationConfiguration());
        modelBuilder.ApplyConfiguration(new ImageConfiguration());
    }
}
