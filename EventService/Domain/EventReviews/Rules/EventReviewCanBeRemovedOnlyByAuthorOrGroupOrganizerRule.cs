using EventService.Domain.ConferenceGroups;
using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.EventReviews.Rules;

public class EventReviewCanBeRemovedOnlyByAuthorOrGroupOrganizerRule : IBaseBusinessRule
{
    private readonly ConferenceGroup _conferenceGroup;
    private readonly MemberId _authorId;
    private readonly MemberId _removingMemberId;

    public EventReviewCanBeRemovedOnlyByAuthorOrGroupOrganizerRule(ConferenceGroup conferenceGroup, MemberId authorId, MemberId removingMemberId)
    {
        _conferenceGroup = conferenceGroup;
        _authorId = authorId;
        _removingMemberId = removingMemberId;
    }

    public bool IsBroken() => _removingMemberId != _authorId && !_conferenceGroup.IsOrganizer(_removingMemberId);

    public string Message => "Only author of comment or group organizer can remove meeting comment.";
}