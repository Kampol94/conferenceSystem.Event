using EventService.Application.Contracts.Commands;

namespace EventService.Application.EventReviews.Commands.AddEventReview;

public class AddEventReviewsCommand : CommandBase<Guid>
{
    public Guid EventId { get; }

    public string Comment { get; }

    public AddEventReviewsCommand(Guid meetingId, string comment)
    {
        EventId = meetingId;
        Comment = comment;
    }
}