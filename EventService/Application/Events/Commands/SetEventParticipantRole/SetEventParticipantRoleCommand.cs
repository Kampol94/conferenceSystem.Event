using EventService.Application.Contracts.Commands;

namespace CompanyName.MyEvents.Modules.Events.Application.Events.SetEventParticipantRole;

public class SetEventParticipantRoleCommand : CommandBase
{
    public Guid MemberId { get; }

    public Guid EventId { get; }

    public SetEventParticipantRoleCommand(Guid memberId, Guid eventId)
    {
        MemberId = memberId;
        EventId = eventId;
    }
}