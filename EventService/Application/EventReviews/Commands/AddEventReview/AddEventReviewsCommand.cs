using EventService.Application.Contracts.Commands;

namespace EventService.Application.EventReviews.Commands.AddEventReview;

public class AddEventReviewsCommand : CommandBase<Guid>
{
    public Guid EventId { get; }

    public string Comment { get; }

    public AddEventReviewsCommand(Guid eventId, string comment)
    {
        EventId = eventId;
        Comment = comment;
    }
}