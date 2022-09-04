using EventService.Domain.Contracts;

namespace EventService.Domain.EventReviews.DomainEvents;

public class EventReviewEditedDomainEvent : DomainEventBase
{
    public EventReviewId EventReviewId { get; }

    public string EditedComment { get; }

    public EventReviewEditedDomainEvent(EventReviewId eventReviewId, string editedComment)
    {
        EventReviewId = eventReviewId;
        EditedComment = editedComment;
    }
}