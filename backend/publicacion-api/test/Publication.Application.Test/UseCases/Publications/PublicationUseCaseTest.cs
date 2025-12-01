using Moq;
using Publicacion.Application.Contracts.Repositories;
using Publicacion.Application.UseCases.Publications;
using DomainPublication = Publicacion.Domain.Entities.Publication;
using Xunit;
using Publicacion.Domain.Entities;
using Publicacion.Application.DTOs;

namespace Publication.Application.Test.UseCases.Publications
{
    public class PublicationUseCases
    {
        private readonly Mock<IPublicationRepository> _publicationRepositoryMock;
        private readonly PublicationUseCase _publicationUseCase;

        public PublicationUseCases()
        {
            _publicationRepositoryMock = new Mock<IPublicationRepository>();
            _publicationUseCase = new PublicationUseCase(_publicationRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsPublications()
        {
            
            _publicationRepositoryMock.Setup(p => p.GetAllAsync()).ReturnsAsync(GetPublications());
            var publicationsDto = await _publicationUseCase.GetAllAsync();

            Assert.NotNull(publicationsDto);
            Assert.Equal(2, publicationsDto.Count);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnPublication()
        {

            _publicationRepositoryMock.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(GetPublications().First());
            var publicationDto = await _publicationUseCase.GetByIdAsync(1);

            Assert.NotNull(publicationDto);
            Assert.Equal(1, publicationDto.Id);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnNull()
        {

            _publicationRepositoryMock.Setup(p => p.GetByIdAsync(It.IsAny<int>()));
            var publicationDto = await _publicationUseCase.GetByIdAsync(1);

            Assert.Null(publicationDto);
        }

        [Fact]
        public async Task ExistAsync_Success()
        {
            _publicationRepositoryMock.Setup(p => p.ExistAsync(It.IsAny<int>())).ReturnsAsync(true);
            var exist = await _publicationUseCase.ExistAsync(1);

            Assert.True(exist);
        }

        [Fact]
        public async Task AddAsync_Success()
        {
            _publicationRepositoryMock.Setup(p => p.AddAsync(It.IsAny<DomainPublication>()));
            await _publicationUseCase.AddAsync(new PublicationDto(1, "test", "test", "test", 1, 10, 1, ""));
            _publicationRepositoryMock.Verify(r => r.AddAsync(It.IsAny<DomainPublication>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_Success()
        {
            _publicationRepositoryMock.Setup(p => p.DeleteAsync(It.IsAny<DomainPublication>()));
            _publicationRepositoryMock.Setup(p => p.GetFirstByIdAsync(It.IsAny<int>())).ReturnsAsync(GetPublications().First());
            await _publicationUseCase.DeleteAsync(1);
            _publicationRepositoryMock.Verify(r => r.DeleteAsync(It.IsAny<DomainPublication>()), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_Success()
        {
            _publicationRepositoryMock.Setup(p => p.UpdateAsync(It.IsAny<DomainPublication>()));
            await _publicationUseCase.UpdateAsync(1, new PublicationDto(1, "test", "test", "test", 1, 10, 1, ""));
            _publicationRepositoryMock.Verify(r => r.UpdateAsync(It.IsAny<DomainPublication>()), Times.Once);
        }

        private static List<DomainPublication> GetPublications()
        {
            return new List<DomainPublication>()
            {
                new DomainPublication()
                {
                    Id = 1,
                    PropertyType = "Test 1",
                    OperationType = "Test 1",
                    Description = "Test 1",
                    Age = 1,
                    Rooms = 1,
                    M2 = 20,
                    LocationCoordinates = "-23.042010, -18.122022",
                    Images = new List<Image>()
                },
                new DomainPublication()
                {
                    Id = 2,
                    PropertyType = "Test 2",
                    OperationType = "Test 2",
                    Description = "Test 2",
                    Age = 1,
                    Rooms = 1,
                    M2 = 20,
                    LocationCoordinates = "-23.042010, -18.122022",
                    Images = new List<Image>()
                }
            };
        }
    }
}
