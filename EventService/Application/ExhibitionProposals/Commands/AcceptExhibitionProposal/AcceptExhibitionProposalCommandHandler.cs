using EventService.Application.Contracts.Commands;
using EventService.Domain.ExhibitionProposals;
using MediatR;

namespace EventService.Application.ExhibitionProposals.Commands.AcceptExhibitionProposal;

public class AcceptExhibitionProposalCommandHandler : ICommandHandler<AcceptExhibitionProposalCommand>
{
    private readonly IExhibitionProposalRepository _exhibitionProposalRepository;

    public AcceptExhibitionProposalCommandHandler(IExhibitionProposalRepository exhibitionProposalRepository)
    {
        _exhibitionProposalRepository = exhibitionProposalRepository;
    }

    public async Task<Unit> Handle(AcceptExhibitionProposalCommand request, CancellationToken cancellationToken)
    {
        ExhibitionProposal? exhibitionProposal = await _exhibitionProposalRepository.GetByIdAsync(new ExhibitionProposalId(request.ExhibitionProposalId));

        if (exhibitionProposal is null)
        {
            throw new Exception("Exhibition must exist.");
        }
        exhibitionProposal.Accept();

        return Unit.Value;
    }
}