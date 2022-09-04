using EventService.Domain.Contracts;

namespace EventService.Domain.EventReviews.DomainEvents;

public class ReplyToEventReviewAddedDomainEvent : DomainEventBase
{
    public EventReviewId EventReviewId { get; }

    public EventReviewId InReplyToEventReviewId { get; }

    public string Reply { get; }

    public ReplyToEventReviewAddedDomainEvent(EventReviewId eventReviewId, EventReviewId inReplyToEventReviewId, string reply)
    {
        EventReviewId = eventReviewId;
        InReplyToEventReviewId = inReplyToEventReviewId;
        Reply = reply;
    }
}