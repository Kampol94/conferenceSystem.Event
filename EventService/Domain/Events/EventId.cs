using EventService.Domain.Contracts;

namespace EventService.Domain.Events;

public class EventId : IdValueBase
{
    public EventId(Guid value)
        : base(value)
    {
    }
}