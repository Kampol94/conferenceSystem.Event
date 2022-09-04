using EventService.Domain.ConferenceGroups;
using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.EventReviews.Rules;

public class ReviewCanBeAddedOnlyByConferenceGroupMemberRule : IBaseBusinessRule
{
    private readonly MemberId _authorId;
    private readonly ConferenceGroup _conferenceGroup;

    public ReviewCanBeAddedOnlyByConferenceGroupMemberRule(MemberId authorId, ConferenceGroup conferenceGroup)
    {
        _authorId = authorId;
        _conferenceGroup = conferenceGroup;
    }

    public bool IsBroken() => !_conferenceGroup.IsMemberOfGroup(_authorId);

    public string Message => "Only event participants can add review";
}