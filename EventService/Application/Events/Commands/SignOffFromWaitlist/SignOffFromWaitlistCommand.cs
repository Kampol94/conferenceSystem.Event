using EventService.Application.Contracts.Commands;

namespace CompanyName.MyEvents.Modules.Events.Application.Events.SignOffMemberFromWaitlist;

public class SignOffFromWaitlistCommand : CommandBase
{
    public Guid EventId { get; }

    public SignOffFromWaitlistCommand(Guid eventId)
    {
        EventId = eventId;
    }
}