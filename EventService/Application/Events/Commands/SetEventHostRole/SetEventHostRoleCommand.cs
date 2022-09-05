using EventService.Application.Contracts.Commands;

namespace CompanyName.MyEvents.Modules.Events.Application.Events.SetEventHostRole;

public class SetEventHostRoleCommand : CommandBase
{
    public Guid MemberId { get; }

    public Guid EventId { get; }

    public SetEventHostRoleCommand(Guid memberId, Guid eventId)
    {
        MemberId = memberId;
        EventId = eventId;
    }
}