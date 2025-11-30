namespace Publicacion.Application.DTOs
{
    public record PublicationDto(
        int Id,
        string? PropertyType,
        string? OperationType,
        string? Description,
        int Rooms, 
        int M2, 
        int Age,
        string? LocationCoordinates
    );
}
