using EventService.Application.Contracts.Commands;

namespace EventService.Application.Events.Commands.SignUpToWaitlist;

public class SignUpToWaitlistCommand : CommandBase
{
    public Guid EventId { get; }

    public SignUpToWaitlistCommand(Guid eventId)
    {
        EventId = eventId;
    }
}