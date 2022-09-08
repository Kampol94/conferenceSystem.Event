using EventService.Application.Contracts.Queries;

namespace EventService.Application.Exhibition.Queries.GetExhibitionDetails;

public class GetExhibitionDetailsQuery : QueryBase<ExhibitionDetailsDto>
{
    public GetExhibitionDetailsQuery(Guid exhibitionId)
    {
        ExhibitionId = exhibitionId;
    }

    public Guid ExhibitionId { get; }
}