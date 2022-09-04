using EventService.Domain.ConferenceGroups;
using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.EventReviews.Rules;

public class RemovingReasonCanBeProvidedOnlyByGroupOrganizerRule : IBaseBusinessRule
{
    private readonly ConferenceGroup _conferenceGroup;
    private readonly MemberId _removingMemberId;
    private readonly string _removingReason;

    public RemovingReasonCanBeProvidedOnlyByGroupOrganizerRule(ConferenceGroup conferenceGroup, MemberId removingMemberId, string removingReason)
    {
        _conferenceGroup = conferenceGroup;
        _removingMemberId = removingMemberId;
        _removingReason = removingReason;
    }

    public bool IsBroken() =>
        !string.IsNullOrEmpty(_removingReason) && !_conferenceGroup.IsOrganizer(_removingMemberId);

    public string Message => "Only group organizer can provide review's removing reason.";
}