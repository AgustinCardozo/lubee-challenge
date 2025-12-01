using Publicacion.Domain.Entities;

namespace Publicacion.Infrastructure.Persistence.Seeds
{
    public static class ImageSeed
    {
        public static List<Image> GetSeedingData()
        {
            return new List<Image>() 
            {
                new Image { Id = 1, PublicationId = 1, Url = "https://imgar.zonapropcdn.com/avisos/resize/1/00/57/58/91/31/1200x1200/2011907562.jpg?isFirstImage=true" },
                new Image { Id = 2, PublicationId = 1, Url = "https://imgar.zonapropcdn.com/avisos/resize/1/00/57/58/91/31/1200x1200/2011907576.jpg" },
                new Image { Id = 3, PublicationId = 1, Url = "https://imgar.zonapropcdn.com/avisos/resize/1/00/57/58/91/31/1200x1200/2011907627.jpg" },

                new Image { Id = 4, PublicationId = 2, Url = "https://imgar.zonapropcdn.com/avisos/resize/1/00/57/52/66/73/1200x1200/2010386134.jpg" },
                new Image { Id = 5, PublicationId = 2, Url = "https://imgar.zonapropcdn.com/avisos/resize/1/00/57/52/66/73/1200x1200/2010386135.jpg?isFirstImage=true" },

                new Image { Id = 6, PublicationId = 3, Url = "https://imgar.zonapropcdn.com/avisos/resize/1/00/57/73/35/73/1200x1200/2015772949.jpg?isFirstImage=true" },
                new Image { Id = 7, PublicationId = 3, Url = "https://imgar.zonapropcdn.com/avisos/resize/1/00/57/73/35/73/1200x1200/2015772950.jpg" },
                new Image { Id = 8, PublicationId = 3, Url = "https://imgar.zonapropcdn.com/avisos/resize/1/00/57/73/35/73/1200x1200/2015772914.jpg" },
                new Image { Id = 9, PublicationId = 3, Url = "https://imgar.zonapropcdn.com/avisos/resize/1/00/57/73/35/73/1200x1200/2015772923.jpg" },

                new Image { Id = 10, PublicationId = 4, Url = "https://imgar.zonapropcdn.com/avisos/resize/1/00/57/66/47/11/1200x1200/2013893636.jpg" },
            };
        }
    }
}
