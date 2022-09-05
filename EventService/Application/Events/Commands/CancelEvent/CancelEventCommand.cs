using EventService.Application.Contracts.Commands;

namespace CompanyName.MyEvents.Modules.Events.Application.Events.CancelEvent;

public class CancelEventCommand : CommandBase
{
    public CancelEventCommand(Guid eventId)
    {
        EventId = eventId;
    }

    public Guid EventId { get; }
}