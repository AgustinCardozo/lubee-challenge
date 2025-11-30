namespace Publicacion.Domain.Entities;

public class Publication
{
    public int Id { get; set; }
    public string? PropertyType { get; set; }
    public string? OperationType { get; set; }
    public string? Description { get; set; }
    public int Rooms { get; set; } //TODO: revisar el tipo
    public int M2 { get; set; } //TODO: revisar el tipo y que sería
    public int Age { get; set; }
    public string? LocationCoordinates { get; set; }
    //public List<string?> Images {  get; set; } //TODO: revisar el tipo y que sería
}
