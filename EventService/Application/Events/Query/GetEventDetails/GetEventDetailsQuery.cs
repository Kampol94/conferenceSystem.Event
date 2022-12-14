using EventService.Application.Contracts.Queries;

namespace EventService.Application.Events.Query.GetEventDetails;

public class GetEventDetailsQuery : QueryBase<GetEventDetailsResponse>
{
    public GetEventDetailsQuery(Guid eventId)
    {
        EventId = eventId;
    }

    public Guid EventId { get; }
}