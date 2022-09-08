using EventService.Application.Contracts.Commands;

namespace EventService.Application.Events.Commands.SetEventParticipantRole;

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