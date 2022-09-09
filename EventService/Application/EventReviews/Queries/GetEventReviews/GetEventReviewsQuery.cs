using EventService.Application.Contracts.Queries;

namespace EventService.Application.EventReviews.Queries.GetEventReviews;

public class GetEventReviewsQuery : QueryBase<List<EventReviewsDto>>
{
    public Guid EventId { get; }

    public GetEventReviewsQuery(Guid eventId)
    {
        EventId = eventId;
    }
}