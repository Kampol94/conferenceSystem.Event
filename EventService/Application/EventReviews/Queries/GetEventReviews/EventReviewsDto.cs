namespace EventService.Application.EventReviews.Queries.GetMeetingComments;

public class EventReviewsDto
{
    public Guid Id { get; }

    public Guid? InReplyToCommentId { get; }

    public Guid AuthorId { get; }

    public string? Comment { get; }

    public DateTime CreateDate { get; }

    public DateTime? EditDate { get; }

    public int LikesCount { get; }
}