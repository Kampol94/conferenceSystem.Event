using EventService.Domain.EventReviews;

namespace EventService.Infrastructure.Domain.EventReviews;

public class EventReviewRepository : IEventReviewRepository
{
    private readonly EventsContext _eventsContext;

    public EventReviewRepository(EventsContext eventsContext)
    {
        _eventsContext = eventsContext;
    }

    public async Task AddAsync(EventReview eventReview)
    {
        _ = await _eventsContext.EventReviews.AddAsync(eventReview);
    }

    public async Task<EventReview?> GetByIdAsync(EventReviewId eventReviewId)
    {
        return await _eventsContext.EventReviews.FindAsync(eventReviewId);
    }
}