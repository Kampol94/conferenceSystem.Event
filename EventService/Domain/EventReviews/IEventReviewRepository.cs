namespace EventService.Domain.EventReviews;

public interface IEventReviewRepository
{
    Task AddAsync(EventReview eventReview);

    Task<EventReview?> GetByIdAsync(EventReviewId eventReviewId);
}