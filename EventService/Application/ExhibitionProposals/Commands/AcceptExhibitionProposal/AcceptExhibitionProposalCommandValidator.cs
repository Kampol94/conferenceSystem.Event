using FluentValidation;

namespace EventService.Application.ExhibitionProposals.Commands.AcceptExhibitionProposal;

public class AcceptExhibitionProposalCommandValidator : AbstractValidator<AcceptExhibitionProposalCommand>
{
    public AcceptExhibitionProposalCommandValidator()
    {
        _ = RuleFor(x => x.ExhibitionProposalId).NotEmpty()
            .WithMessage("Id of Exhibition proposal cannot be empty");
    }
}