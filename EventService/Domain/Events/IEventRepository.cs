namespace EventService.Domain.Events;

public interface IEventRepository
{
    Task AddAsync(Event @event);

    Task<Event> GetByIdAsync(EventId id);
}