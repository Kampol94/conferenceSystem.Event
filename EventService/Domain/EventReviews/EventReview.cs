using EventService.Domain.Contracts;
using EventService.Domain.EventReviews.DomainEvents;
using EventService.Domain.EventReviews.Rules;
using EventService.Domain.Events;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;

namespace EventService.Domain.EventReviews;

public class EventReview : BaseEntity
{
    public EventReviewId Id { get; }

    private readonly EventId _eventId;

    private readonly MemberId _authorId;

    private readonly EventReviewId? _inReplyToReviewId;

    private string _text;

    private readonly DateTime _createDate;

    private DateTime? _editDate;

    private bool _isRemoved;

    private string? _removedByReason;

    private EventReview(
        EventId eventId,
        MemberId authorId,
        string text,
        EventReviewId? inReplyToReviewId,
        Exhibition exhibition)
    {
        CheckRule(new ReviewTextMustBeProvidedRule(text));
        CheckRule(new ReviewCanBeAddedOnlyByExhibitionMemberRule(authorId, exhibition));

        Id = new EventReviewId(Guid.NewGuid());
        _eventId = eventId;
        _authorId = authorId;
        _text = text;

        _inReplyToReviewId = inReplyToReviewId;

        _createDate = DateTime.Now;
        _editDate = null;

        _isRemoved = false;
        _removedByReason = null;

        if (inReplyToReviewId is null)
        {
            AddDomainEvent(new EventReviewAddedDomainEvent(Id, _eventId, text));
        }
        else
        {
            AddDomainEvent(new ReplyToEventReviewAddedDomainEvent(Id, inReplyToReviewId, text));
        }
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private EventReview()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    public void Edit(MemberId editorId, string editedReview)
    {
        CheckRule(new ReviewTextMustBeProvidedRule(editedReview));
        CheckRule(new EventReviewCanBeEditedOnlyByAuthorRule(_authorId, editorId));

        _text = editedReview;
        _editDate = DateTime.Now;

        AddDomainEvent(new EventReviewEditedDomainEvent(Id, editedReview));
    }

    public void Remove(MemberId removingMemberId, Exhibition exhibition, string reason)
    {
        CheckRule(new EventReviewCanBeRemovedOnlyByAuthorOrExhibitionOrganizerRule(exhibition, _authorId, removingMemberId));
        CheckRule(new RemovingReasonCanBeProvidedOnlyByExhibitionOrganizerRule(exhibition, removingMemberId, reason));

        _isRemoved = true;
        _removedByReason = reason ?? string.Empty;

        AddDomainEvent(new EventReviewRemovedDomainEvent(Id));
    }

    public EventReview Reply(MemberId replierId, string reply, Exhibition exhibition)
    {
        return new EventReview(
                _eventId,
                replierId,
                reply,
                Id,
                exhibition);
    }

    public EventId GetEventId()
    {
        return _eventId;
    }

    public static EventReview Create(
        EventId eventId,
        MemberId authorId,
        string review,
        Exhibition exhibition)
    {
        return new EventReview(
                eventId,
                authorId,
                review,
                inReplyToReviewId: null,
                exhibition);
    }
}