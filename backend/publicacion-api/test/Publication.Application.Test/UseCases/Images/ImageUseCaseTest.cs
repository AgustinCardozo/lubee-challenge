using Moq;
using Publicacion.Application.Contracts.Repositories;
using Publicacion.Application.UseCases.Images;
using Publicacion.Domain.Entities;
using Xunit;

namespace Publication.Application.Test.UseCases.Images
{
    public class ImageUseCaseTest
    {
        private readonly Mock<IImageRepository> _imageRepositoryMock;
        private readonly ImageUseCase _imageUseCase;

        public ImageUseCaseTest()
        {
            _imageRepositoryMock = new Mock<IImageRepository>();
            _imageUseCase = new ImageUseCase(_imageRepositoryMock.Object);
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

            _imageRepositoryMock.Setup(i => i.GetByPublicationIdAsync(It.IsAny<int>())).ReturnsAsync(images);
            var imagesDto = await _imageUseCase.GetByPublicationIdAsync(10);

            Assert.NotNull(imagesDto);
            Assert.Equal(2, imagesDto.Count);
        }

        [Fact]
        public async Task GetGetByPublicationIdAsync_ReturnEmpty()
        {
            var images = new List<Image>();

            _imageRepositoryMock.Setup(i => i.GetByPublicationIdAsync(It.IsAny<int>())).ReturnsAsync(images);
            var imagesDto = await _imageUseCase.GetByPublicationIdAsync(10);

            Assert.Empty(imagesDto);
        }
    }
}
