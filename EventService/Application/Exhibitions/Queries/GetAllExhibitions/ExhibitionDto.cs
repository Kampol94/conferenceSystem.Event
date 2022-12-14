namespace EventService.Application.Exhibitions.Queries.GetAllExhibitions;

public class ExhibitionDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? LocationCountryCode { get; set; }

    public string? LocationCity { get; set; }
}