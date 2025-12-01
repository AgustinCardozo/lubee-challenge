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

            builder.HasMany(p => p.Images) // La publicación tiene muchas imágenes
                .WithOne(i => i.Publication) // Cada imagen pertenece a una sola publicación
                .HasForeignKey(i => i.PublicationId) // La FK en la tabla Imagen se llama PublicacionId
                .OnDelete(DeleteBehavior.Cascade); // Si se borra la Publicación, se borran sus Imágenes

            builder.HasData(PublicationSeed.GetSeedingData());
        }
    }
}
