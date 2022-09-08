using EventService.Application.Contracts.Commands;

namespace EventService.Application.EventReviews.Commands.EditEventReview;

public class EditEventReviewsCommand : CommandBase
{
    public Guid EventReviewsId { get; }

    public string EditedReview { get; }

    public EditEventReviewsCommand(Guid eventReviewsId, string editedReview)
    {
        EditedReview = editedReview;
        EventReviewsId = eventReviewsId;
    }
}