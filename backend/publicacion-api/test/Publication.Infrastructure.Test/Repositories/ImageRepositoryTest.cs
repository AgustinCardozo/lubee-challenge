using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Publicacion.Domain.Entities;
using Publicacion.Infrastructure.Persistence;
using Publicacion.Infrastructure.Repository;
using Xunit;

namespace Publication.Infrastructure.Test.Repositories
{
    public class ImageRepositoryTest
    {
        private readonly Mock<PublicationContext> _mockContext;
        private readonly ImageRepository _imageRepository;

        public ImageRepositoryTest()
        {
            _mockContext = new Mock<PublicationContext>(new DbContextOptions<PublicationContext>());
            _imageRepository = new ImageRepository(_mockContext.Object);
        }

        [Fact]
        public async Task GetByPublicationIdAsync_ReturnsImages()
        {
            var images = new List<Image>()
            {
                new Image()
                {
                    Id = 1,
                    Url = "https://test1.com",
                    PublicationId = 1,
                },
                new Image()
                {
                    Id = 2,
                    Url = "https://test2.com",
                    PublicationId = 1,
                }
            };

            _mockContext.Setup(x => x.Images).ReturnsDbSet(images);
            _mockContext.Setup(m => m.Set<Image>()).Returns(_mockContext.Object.Images);
            var imagesDb = await _imageRepository.GetByPublicationIdAsync(1);

            Assert.NotNull(imagesDb);
            Assert.Equal(2, imagesDb.Count);
            Assert.DoesNotContain(imagesDb, i => i.Id == 3);
        }
    }
}
