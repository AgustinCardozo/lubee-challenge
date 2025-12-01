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
                    PropertyType = "Casa",
                    OperationType = "Alquiler",
                    Description = "Casa con patio y pileta para alquilar en zona tranquila.",
                    Rooms = 2,
                    M2 = 100,
                    Age = 20,
                    LocationCoordinates = "-34.5912740626822, -58.44926342405723"
                },
                new Publication
                {
                    Id = 3,
                    PropertyType = "Casa",
                    OperationType = "Venta",
                    Description = "Hermosa casa familiar con jardín amplio.",
                    Rooms = 5,
                    M2 = 250,
                    Age = 10,
                    LocationCoordinates = "-34.545388102550206, -58.44912493444169"
                },
                new Publication
                {
                    Id = 4,
                    PropertyType = "Departamento",
                    OperationType = "Venta",
                    Description = "Departamento para excelente iluminación y ubicado a metros de Plaza Serrano.",
                    Rooms = 2,
                    M2 = 60,
                    Age = 5,
                    LocationCoordinates = "-33.15161855419031, -68.89191390749127"
                },
                new Publication
                {
                    Id = 5,
                    PropertyType = "Oficina",
                    OperationType = "Alquiler",
                    Description = "Oficina moderna en Microcentro, ideal para 5 puestos de trabajo.",
                    Rooms = 3, 
                    M2 = 65,
                    Age = 5,
                    LocationCoordinates = "-34.60792311626675, -58.36964480190205"
                },
                new Publication
                {
                    Id = 6,
                    PropertyType = "Departamento",
                    OperationType = "Venta",
                    Description = "Monoambiente en Palermo, con balcón y amenities de lujo.",
                    Rooms = 1,
                    M2 = 45,
                    Age = 2,
                    LocationCoordinates = "-34.57966563810134, -58.42070739762831"
                },
                new Publication
                {
                    Id = 7,
                    PropertyType = "Casa",
                    OperationType = "Alquiler",
                    Description = "Casa estilo rústico en las afueras, con mucha tranquilidad.",
                    Rooms = 6,
                    M2 = 300,
                    Age = 25,
                    LocationCoordinates = "-34.47886239795676, -58.530800851190776"
                },
                new Publication
                {
                    Id = 8,
                    PropertyType = "Terreno",
                    OperationType = "Venta",
                    Description = "Lote con servicios al día en barrio cerrado, seguridad 24h.",
                    Rooms = 0,
                    M2 = 450,
                    Age = 0,
                    LocationCoordinates = "-34.386480564005815, -58.70008852211937"
                },
                new Publication
                {
                    Id = 9,
                    PropertyType = "Oficina",
                    OperationType = "Alquiler",
                    Description = "Espacio de coworking flexible en Belgrano, incluye todos los servicios.",
                    Rooms = 4,
                    M2 = 90,
                    Age = 8,
                    LocationCoordinates = "-34.55660331473092, -58.449894494381375"
                },
                new Publication
                {
                    Id = 10,
                    PropertyType = "Departamento",
                    OperationType = "Venta",
                    Description = "PH antiguo reciclado con terraza privada en San Telmo.",
                    Rooms = 3,
                    M2 = 120,
                    Age = 50,
                    LocationCoordinates = "-34.625080194090806, -58.37073447943592"
                }
            };
        }
    }
}
