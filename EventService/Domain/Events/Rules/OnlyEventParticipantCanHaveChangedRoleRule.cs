using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.Events.Rules;

public class OnlyEventParticipantCanHaveChangedRoleRule : IBaseBusinessRule
{
    private readonly List<EventParticipant> _participants;

    private readonly MemberId _newOrganizerId;

    public OnlyEventParticipantCanHaveChangedRoleRule(List<EventParticipant> participants, MemberId newOrganizerId)
    {
        _participants = participants;
        _newOrganizerId = newOrganizerId;
    }

    public bool IsBroken()
    {
        return _participants.SingleOrDefault(x => x.IsActiveParticipant(_newOrganizerId)) == null;
    }

    public string Message => "Only event participants can be set as organizer of event";
}