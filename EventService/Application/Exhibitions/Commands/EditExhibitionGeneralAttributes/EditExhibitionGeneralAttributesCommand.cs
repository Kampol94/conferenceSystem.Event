using EventService.Application.Contracts.Commands;

namespace EventService.Application.Exhibitions.Commands.EditExhibitionGeneralAttributes;

public class EditExhibitionGeneralAttributesCommand : CommandBase
{
    public EditExhibitionGeneralAttributesCommand(Guid exhibitionId, string name, string description, string locationCity, string locationCountry)
    {
        ExhibitionId = exhibitionId;
        Name = name;
        Description = description;
        LocationCity = locationCity;
        LocationCountry = locationCountry;
    }

    public string LocationCountry { get; }

    public Guid ExhibitionId { get; }

    public string Name { get; }

    public string Description { get; }

    public string LocationCity { get; }
}