namespace Publicacion.Application.DTOs
{
    public record ImageDto(
        int Id,
        string? Url,
        int PublicationId
    );
}
