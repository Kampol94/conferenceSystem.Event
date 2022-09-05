using EventService.Application.Contracts.Commands;

namespace CompanyName.MyEvents.Modules.Events.Application.Events.SignUpMemberToWaitlist;

public class SignUpToWaitlistCommand : CommandBase
{
    public Guid EventId { get; }

    public SignUpToWaitlistCommand(Guid eventId)
    {
        EventId = eventId;
    }
}