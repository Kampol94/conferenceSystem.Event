using EventService.Domain.Contracts;

namespace EventService.Domain.EventReviews.DomainEvents;

public class EventReviewRemovedDomainEvent : DomainEventBase
{
    public EventReviewId EventReviewId { get; }

    public EventReviewRemovedDomainEvent(EventReviewId eventReviewId)
    {
        EventReviewId = eventReviewId;
    }
}