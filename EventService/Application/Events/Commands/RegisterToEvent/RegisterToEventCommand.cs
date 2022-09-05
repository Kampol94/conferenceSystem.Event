using EventService.Application.Contracts.Commands;

namespace EventService.Application.Events.Commands.RegisterToEvent;

public class RegisterToEventCommand : CommandBase
{
    public Guid EventId { get; }

    public RegisterToEventCommand(Guid eventId)
    {
        EventId = eventId;
    }
}