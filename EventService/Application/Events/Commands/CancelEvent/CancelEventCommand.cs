using EventService.Application.Contracts.Commands;

namespace EventService.Application.Events.Commands.CancelEvent;

public class CancelEventCommand : CommandBase
{
    public CancelEventCommand(Guid eventId)
    {
        EventId = eventId;
    }

    public Guid EventId { get; }
}