using System;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions.GetExhibitionDetails;

public class ExhibitionDetailsDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string LocationCountryCode { get; set; }

    public string LocationCity { get; set; }

    public int MembersCount { get; set; }
}