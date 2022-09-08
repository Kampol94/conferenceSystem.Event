using EventService.Application.Contracts.Commands;
using EventService.Domain.Exhibitions;
using MediatR;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions.CreateNewExhibition;

internal class CreateNewExhibitionCommandHandler : ICommandHandler<CreateNewExhibitionCommand>
{
    private readonly IExhibitionRepository _ExhibitionRepository;
    private readonly IExhibitionProposalRepository _ExhibitionProposalRepository;

    internal CreateNewExhibitionCommandHandler(
        IExhibitionRepository ExhibitionRepository,
        IExhibitionProposalRepository ExhibitionProposalRepository)
    {
        _ExhibitionRepository = ExhibitionRepository;
        _ExhibitionProposalRepository = ExhibitionProposalRepository;
    }

    public async Task<Unit> Handle(CreateNewExhibitionCommand request, CancellationToken cancellationToken)
    {
        var ExhibitionProposal = await _ExhibitionProposalRepository.GetByIdAsync(request.ExhibitionProposalId);

        var Exhibition = ExhibitionProposal.CreateExhibition();

        await _ExhibitionRepository.AddAsync(Exhibition);

        return Unit.Value;
    }
}