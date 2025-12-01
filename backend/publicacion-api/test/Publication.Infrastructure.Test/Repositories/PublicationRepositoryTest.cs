using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Publicacion.Domain.Entities;
using Publicacion.Infrastructure.Persistence;
using Publicacion.Infrastructure.Repository;
using Xunit;
using DomainPublication = Publicacion.Domain.Entities.Publication;

namespace Publication.Infrastructure.Test.Repositories
{
    public class PublicationRepositoryTest
    {
        private readonly Mock<PublicationContext> _mockContext;
        private readonly PublicationRepository _repository;

        public PublicationRepositoryTest()
        {
            _mockContext = new Mock<PublicationContext>(new DbContextOptions<PublicationContext>());
            _repository = new PublicationRepository(_mockContext.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnPublications()
        {
            _mockContext.Setup(x => x.Publications).ReturnsDbSet(GetPublications());
            _mockContext.Setup(m => m.Set<DomainPublication>()).Returns(_mockContext.Object.Publications);

            var publicationsDb = await _repository.GetAllAsync();

            Assert.NotNull(publicationsDb);
            Assert.Equal(2, publicationsDb.Count);
            Assert.DoesNotContain(publicationsDb, i => i.Id == 3);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnPublication()
        {
            _mockContext.Setup(x => x.Publications.FindAsync(2).Result).Returns(GetPublications().Find(e => e.Id == 2));
            _mockContext.Setup(m => m.Set<DomainPublication>()).Returns(_mockContext.Object.Publications);

            var publicationDb = await _repository.GetByIdAsync(2);

            Assert.NotNull(publicationDb);
            Assert.Equal(2, publicationDb.Id);
        }

        [Fact]
        public async Task GetFirstByIdAsync_ReturnPublication()
        {
            _mockContext.Setup(x => x.Publications).ReturnsDbSet(GetPublications());
            _mockContext.Setup(m => m.Set<DomainPublication>()).Returns(_mockContext.Object.Publications);

            var publicationDb = await _repository.GetFirstByIdAsync(1);

            Assert.NotNull(publicationDb);
            Assert.Equal(1, publicationDb.Id);
        }

        [Fact]
        public async Task AddAsync_Success()
        {
            _mockContext.Setup(x => x.Publications).ReturnsDbSet(GetPublications());
            _mockContext.Setup(m => m.Set<DomainPublication>()).Returns(_mockContext.Object.Publications);
            var newPublication = new DomainPublication();

            await _repository.AddAsync(newPublication);

            _mockContext.Verify(m => m.Add(newPublication), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(CancellationToken.None), Times.Once());
        }

        [Fact]
        public async Task DeleteAsync_Success()
        {
            _mockContext.Setup(x => x.Publications).ReturnsDbSet(GetPublications());
            _mockContext.Setup(m => m.Set<DomainPublication>()).Returns(_mockContext.Object.Publications);
            var newPublication = new DomainPublication();

            await _repository.DeleteAsync(newPublication);

            _mockContext.Verify(m => m.Remove(newPublication), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(CancellationToken.None), Times.Once());
        }

        [Fact]
        public async Task UpdateAsync_Success()
        {
            _mockContext.Setup(x => x.Publications).ReturnsDbSet(GetPublications());
            _mockContext.Setup(m => m.Set<DomainPublication>()).Returns(_mockContext.Object.Publications);
            var newPublication = new DomainPublication();

            await _repository.UpdateAsync(newPublication);

            _mockContext.Verify(m => m.Update(newPublication), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(CancellationToken.None), Times.Once());
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
