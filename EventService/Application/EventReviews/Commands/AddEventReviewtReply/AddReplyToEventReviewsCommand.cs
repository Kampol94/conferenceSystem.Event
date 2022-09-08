using EventService.Application.Contracts.Commands;

namespace EventService.Application.EventReviews.Commands.AddEventReviewtReply;

public class AddReplyToEventReviewsCommand : CommandBase<Guid>
{
    public Guid InReplyToEventReviewId { get; }

    public string Reply { get; }

    public AddReplyToEventReviewsCommand(Guid inReplyToCommentId, string reply)
    {
        InReplyToEventReviewId = inReplyToCommentId;
        Reply = reply;
    }
}