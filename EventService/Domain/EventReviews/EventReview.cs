using EventService.Domain.EventGroups;
using EventService.Domain.Events;
using EventService.Domain.Members;

namespace EventService.Domain.EventReviews;

public class EventReview
{
    internal static EventReview Create(EventId id, MemberId authorId, string comment, EventGroup eventGroup)
    {
        throw new NotImplementedException();
    }
}