using FluentValidation;

namespace EventService.Application.ExhibitionProposals.Commands.ProposeExhibition;

public class ProposeExhibitionCommandValidator : AbstractValidator<ProposeExhibitionCommand>
{
    public ProposeExhibitionCommandValidator()
    {
        _ = RuleFor(x => x.Name).NotEmpty().WithMessage("Exhibition name cannot be empty");
    }
}