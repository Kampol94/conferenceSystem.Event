using FluentValidation;

namespace EventService.Application.EventReviews.Commands.EditEventReview;

public class EditEventReviewsCommandValidator : AbstractValidator<EditEventReviewsCommand>
{
    public EditEventReviewsCommandValidator()
    {
        _ = RuleFor(c => c.EditedReview).NotNull().NotEmpty()
            .WithMessage("Review cannot be null or empty.");
    }
}