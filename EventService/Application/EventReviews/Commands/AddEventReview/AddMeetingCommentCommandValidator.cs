using FluentValidation;

namespace EventService.Application.EventReviews.Commands.AddEventReview;

internal class AddEventReviewsCommandValidator : AbstractValidator<AddEventReviewsCommand>
{
    public AddEventReviewsCommandValidator()
    {
        RuleFor(c => c.EventId).NotEmpty()
            .WithMessage("Id of meeting member cannot be empty.");

        RuleFor(c => c.Comment).NotNull().NotEmpty()
            .WithMessage("Comment cannot be null or empty.");
    }
}