using System;
using CompanyName.MyMeetings.Modules.Meetings.Application.Configuration.Queries;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions.GetExhibitionDetails;

public class GetExhibitionDetailsQuery : QueryBase<ExhibitionDetailsDto>
{
    public GetExhibitionDetailsQuery(Guid ExhibitionId)
    {
        ExhibitionId = ExhibitionId;
    }

    public Guid ExhibitionId { get; }
}