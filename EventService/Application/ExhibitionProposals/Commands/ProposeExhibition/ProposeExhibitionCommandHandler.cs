using EventService.Application.Contracts.Commands;
using EventService.Domain.ExhibitionProposals;
using EventService.Domain.Members;

namespace EventService.Application.ExhibitionProposals.Commands.ProposeExhibition;

public class ProposeExhibitionCommandHandler : ICommandHandler<ProposeExhibitionCommand, Guid>
{
    private readonly IExhibitionProposalRepository _exhibitionProposalRepository;
    private readonly IMemberContext _memberContext;

    public ProposeExhibitionCommandHandler(
        IExhibitionProposalRepository exhibitionProposalRepository,
        IMemberContext memberContext)
    {
        _exhibitionProposalRepository = exhibitionProposalRepository;
        _memberContext = memberContext;
    }

    public async Task<Guid> Handle(ProposeExhibitionCommand request, CancellationToken cancellationToken)
    {
        var exhibitionProposal = ExhibitionProposal.ProposeNew(
            request.Name,
            request.Description,
            _memberContext.MemberId);

        await _exhibitionProposalRepository.AddAsync(exhibitionProposal);

        return exhibitionProposal.Id.Value;
    }
}