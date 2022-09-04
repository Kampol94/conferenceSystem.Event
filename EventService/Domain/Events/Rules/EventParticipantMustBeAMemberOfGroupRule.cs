using EventService.Domain.Contracts;
using EventService.Domain.EventGroups;
using EventService.Domain.Members;

namespace EventService.Domain.Events.Rules;

public class EventParticipantMustBeAMemberOfGroupRule : IBaseBusinessRule
{
    private readonly ConferenceGroups _eventGroup;

    private readonly MemberId _participantId;

    internal EventParticipantMustBeAMemberOfGroupRule(MemberId participantId, ConferenceGroups eventGroup)
    {
        _participantId = participantId;
        _eventGroup = eventGroup;
    }

    public bool IsBroken()
    {
        return !_eventGroup.IsMemberOfGroup(_participantId);
    }

    public string Message => "Event participant must be a member of group";
}