using EventService.Domain.Contracts;
using EventService.Domain.EventGroups;
using EventService.Domain.Members;

namespace EventService.Domain.Events.Rules;

public class OnlyEventOrGroupOrganizerCanSetEventMemberRolesRule : IBaseBusinessRule
{
    private readonly MemberId _settingMemberId;
    private readonly EventGroup _eventGroup;
    private readonly List<EventParticipant> _participants;

    public OnlyEventOrGroupOrganizerCanSetEventMemberRolesRule(MemberId settingMemberId, EventGroup eventGroup, List<EventParticipant> participants)
    {
        _settingMemberId = settingMemberId;
        _eventGroup = eventGroup;
        _participants = participants;
    }

    public bool IsBroken()
    {
        var settingMember = _participants.SingleOrDefault(x => x.IsActiveParticipant(_settingMemberId));

        var isHost = settingMember != null && settingMember.IsActiveHost();
        var isOrganizer = _eventGroup.IsOrganizer(_settingMemberId);

        return !isHost && !isOrganizer;
    }

    public string Message => "Only event host or group organizer can set event member roles";
}