using EventService.Application.Contracts.Commands;
using EventService.Domain.ExhibitionProposals;
using EventService.Domain.Exhibitions;
using MediatR;

namespace EventService.Application.Exhibition.Commands.CreateNewExhibition;

public class CreateNewExhibitionCommandHandler : ICommandHandler<CreateNewExhibitionCommand>
{
    private readonly IExhibitionRepository _exhibitionRepository;
    private readonly IExhibitionProposalRepository _exhibitionProposalRepository;

    public CreateNewExhibitionCommandHandler(
        IExhibitionRepository exhibitionRepository,
        IExhibitionProposalRepository exhibitionProposalRepository)
    {
        _exhibitionRepository = exhibitionRepository;
        _exhibitionProposalRepository = exhibitionProposalRepository;
    }

    public async Task<Unit> Handle(CreateNewExhibitionCommand request, CancellationToken cancellationToken)
    {
        var exhibitionProposal = await _exhibitionProposalRepository.GetByIdAsync(request.ExhibitionProposalId);

        var Exhibition = exhibitionProposal.CreateExhibition();

        await _exhibitionRepository.AddAsync(Exhibition);

        return Unit.Value;
    }
}