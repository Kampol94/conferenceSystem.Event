using EventService.Domain.Events;
using EventService.Infrastructure;

namespace CompanyName.MyMeetings.Modules.Meetings.Infrastructure.Domain.Meetings
{
    internal class EventRepository : IEventRepository
    {
        private readonly EventsContext _meetingsContext;

        internal EventRepository(EventsContext meetingsContext)
        {
            _meetingsContext = meetingsContext;
        }

        public async Task AddAsync(Event @event)
        {
            await _meetingsContext.Events.AddAsync(@event);
        }

        public async Task<Event?> GetByIdAsync(EventId id)
        {
            return await _meetingsContext.Events.FindAsync(id);
        }
    }
}