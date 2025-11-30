using Publicacion.Domain.Entities;

namespace Publicacion.Infrastructure.Persistence.Seeds
{
    public class PublicationSeed
    {
        public static List<Publication> GetSeedingData() 
        {
            return new List<Publication>()
            {
                new Publication
                {
                    Id = 1,
                    PropertyType = "Casa",
                    OperationType = "Venta",
                    Description = "Casa con jardin y pileta, ideal para familia.",
                    Rooms = 4,
                    M2 = 140,
                    Age = 15,
                    LocationCoordinates = "-34.57073690807198, -58.41713926905615"
                },
                new Publication
                {
                    Id = 2,
                    PropertyType = "Departamento",
                    OperationType = "Alquiler",
                    Description = "Departamento de dos ambientes en Villa Crespo",
                    Rooms = 2,
                    M2 = 35,
                    Age = 20,
                    LocationCoordinates = "-34.5912740626822, -58.44926342405723"
                }
            };
        }
    }
}
