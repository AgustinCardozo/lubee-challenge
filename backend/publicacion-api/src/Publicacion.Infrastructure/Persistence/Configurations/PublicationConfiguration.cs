using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Publicacion.Domain.Entities;
using Publicacion.Infrastructure.Persistence.Seeds;

namespace Publicacion.Infrastructure.Persistence.EntityConfigurations
{
    public class PublicationConfiguration : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PropertyType)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.OperationType)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(250);

            builder.HasMany(p => p.Images) 
                .WithOne(i => i.Publication) 
                .HasForeignKey(i => i.PublicationId) 
                .OnDelete(DeleteBehavior.Cascade); // Si se borra la Publicación, se borran sus Imágenes

            builder.HasData(PublicationSeed.GetSeedingData());
        }
    }
}
