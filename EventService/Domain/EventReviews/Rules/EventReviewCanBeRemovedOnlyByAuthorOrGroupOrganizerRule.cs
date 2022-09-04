using EventService.Domain.Contracts;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;

namespace EventService.Domain.EventReviews.Rules;

public class EventReviewCanBeRemovedOnlyByAuthorOrExhibitionOrganizerRule : IBaseBusinessRule
{
    private readonly Exhibition _exhibition;
    private readonly MemberId _authorId;
    private readonly MemberId _removingMemberId;

    public EventReviewCanBeRemovedOnlyByAuthorOrExhibitionOrganizerRule(Exhibition exhibition, MemberId authorId, MemberId removingMemberId)
    {
        _exhibition = exhibition;
        _authorId = authorId;
        _removingMemberId = removingMemberId;
    }

    public bool IsBroken() => _removingMemberId != _authorId && !_exhibition.IsOrganizer(_removingMemberId);

    public string Message => "Only author of comment or exhibition organizer can remove meeting comment.";
}