using EventService.Application.Contracts.Queries;

namespace EventService.Application.Exhibition.Queries.GetMeetingGroupDetails;

public class GetExhibitionDetailsQuery : QueryBase<ExhibitionDetailsDto>
{
    public GetExhibitionDetailsQuery(Guid exhibitionId)
    {
        ExhibitionId = exhibitionId;
    }

    public Guid ExhibitionId { get; }
}