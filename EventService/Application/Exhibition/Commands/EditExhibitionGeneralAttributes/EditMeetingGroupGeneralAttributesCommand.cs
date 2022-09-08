using System;
using CompanyName.MyMeetings.Modules.Meetings.Application.Contracts;
using MediatR;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions.EditExhibitionGeneralAttributes;

public class EditExhibitionGeneralAttributesCommand : CommandBase
{
    public EditExhibitionGeneralAttributesCommand(Guid ExhibitionId, string name, string description, string locationCity, string locationCountry)
    {
        ExhibitionId = ExhibitionId;
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