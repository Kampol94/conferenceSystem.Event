using FluentValidation;

namespace EventService.Application.ExhibitionProposals.Commands.AcceptExhibitionProposal;

internal class AcceptExhibitionProposalCommandValidator : AbstractValidator<AcceptExhibitionProposalCommand>
{
    public AcceptExhibitionProposalCommandValidator()
    {
        RuleFor(x => x.ExhibitionProposalId).NotEmpty()
            .WithMessage("Id of Exhibition proposal cannot be empty");
    }
}