using EventService.Domain.Contracts;

namespace EventService.Domain.EventReviews;

public class EventReviewId : IdValueBase
{
    public EventReviewId(Guid value)
        : base(value)
    {
    }
}