namespace Publicacion.Domain.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public int PublicationId { get; set; }
        public Publication? Publication { get; set; }
    }
}
