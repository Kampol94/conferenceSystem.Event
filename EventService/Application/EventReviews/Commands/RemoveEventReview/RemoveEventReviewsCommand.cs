using EventService.Application.Contracts.Commands;

namespace EventService.Application.EventReviews.Commands.RemoveEventReview;

public class RemoveEventReviewsCommand : CommandBase
{
    public Guid EventReviewsId { get; }

    public string Reason { get; }

    public RemoveEventReviewsCommand(Guid eventReviewsId, string reason)
    {
        EventReviewsId = eventReviewsId;
        Reason = reason;
    }
}