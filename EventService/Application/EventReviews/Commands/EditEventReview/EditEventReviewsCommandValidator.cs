using FluentValidation;

namespace EventService.Application.EventReviews.Commands.EditEventReview;

internal class EditEventReviewsCommandValidator : AbstractValidator<EditEventReviewsCommand>
{
    public EditEventReviewsCommandValidator()
    {
        RuleFor(c => c.EditedReview).NotNull().NotEmpty()
            .WithMessage("Review cannot be null or empty.");
    }
}