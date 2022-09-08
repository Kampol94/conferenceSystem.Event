using FluentValidation;

namespace EventService.Application.ExhibitionProposals.Commands.ProposeExhibition;

internal class ProposeExhibitionCommandValidator : AbstractValidator<ProposeExhibitionCommand>
{
    public ProposeExhibitionCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Exhibition name cannot be empty");
    }
}