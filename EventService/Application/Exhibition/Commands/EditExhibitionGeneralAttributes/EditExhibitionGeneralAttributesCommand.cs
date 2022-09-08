using EventService.Application.Contracts.Commands;

namespace EventService.Application.Exhibition.Commands.EditExhibitionGeneralAttributes;

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

    internal Guid ExhibitionId { get; }

    internal string Name { get; }

    internal string Description { get; }

    internal string LocationCity { get; }
}