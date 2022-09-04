using EventService.Domain.Contracts;
using EventService.Domain.Events;

namespace EventService.Domain.EventReviews.DomainEvents;

public class EventReviewAddedDomainEvent : DomainEventBase
{
    public EventReviewId EventReviewId { get; }

    public EventId EventId { get; }

    public string Comment { get; }

    public EventReviewAddedDomainEvent(EventReviewId eventReviewId, EventId eventId, string text)
    {
        EventReviewId = eventReviewId;
        EventId = eventId;
        Comment = text;
    }
}