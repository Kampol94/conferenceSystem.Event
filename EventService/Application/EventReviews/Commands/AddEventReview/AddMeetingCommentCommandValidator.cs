using FluentValidation;

namespace EventService.Application.EventReviews.Commands.AddEventReview;

public class AddEventReviewsCommandValidator : AbstractValidator<AddEventReviewsCommand>
{
    public AddEventReviewsCommandValidator()
    {
        _ = RuleFor(c => c.EventId).NotEmpty()
            .WithMessage("Id of meeting member cannot be empty.");

        _ = RuleFor(c => c.Comment).NotNull().NotEmpty()
            .WithMessage("Comment cannot be null or empty.");
    }
}