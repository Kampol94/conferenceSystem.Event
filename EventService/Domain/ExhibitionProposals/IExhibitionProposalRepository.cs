namespace EventService.Domain.ExhibitionProposals;

public interface IExhibitionProposalRepository
{
    Task AddAsync(ExhibitionProposal exhibitionProposal);

    Task<ExhibitionProposal> GetByIdAsync(ExhibitionProposalId exhibitionProposalId);
}