namespace EventService.Application.EventReviews.Queries.GetEventReviews;

public class EventReviewsDto
{
    public Guid Id { get; }

    public Guid? InReplyToReviewId { get; }

    public Guid AuthorId { get; }

    public string? Text { get; }

    public DateTime CreateDate { get; }

    public DateTime? EditDate { get; }

    public int LikesCount { get; }
}