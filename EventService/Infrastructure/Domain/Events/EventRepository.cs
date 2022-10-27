using EventService.Domain.Events;

namespace EventService.Infrastructure.Domain.Events;

public class EventRepository : IEventRepository
{
    private readonly EventsContext _meetingsContext;

    public EventRepository(EventsContext meetingsContext)
    {
        _meetingsContext = meetingsContext;
    }

    public async Task AddAsync(Event @event)
    {
        _ = await _meetingsContext.Events.AddAsync(@event);
    }

    public async Task<Event?> GetByIdAsync(EventId id)
    {
        return await _meetingsContext.Events.FindAsync(id);
    }
}