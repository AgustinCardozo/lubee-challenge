using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Publicacion.Domain.Entities;
using Publicacion.Infrastructure.Persistence.Seeds;

namespace Publicacion.Infrastructure.Persistence.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(i => i.Url)
                .HasMaxLength(300)
                .IsRequired();
            builder.HasOne(i => i.Publication)
                   .WithMany(p => p.Images)
                   .HasForeignKey(i => i.PublicationId);
            builder.HasData(ImageSeed.GetSeedingData());
        }
    }
}
