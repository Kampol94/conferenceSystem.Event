using EventService.Application.Contracts.Commands;

namespace EventService.Application.Events.Commands.SignOffFromWaitlist;

public class SignOffFromWaitlistCommand : CommandBase
{
    public Guid EventId { get; }

    public SignOffFromWaitlistCommand(Guid eventId)
    {
        EventId = eventId;
    }
}