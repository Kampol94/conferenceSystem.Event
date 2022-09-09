using EventService.Domain.ExhibitionProposals;
using Microsoft.EntityFrameworkCore;

namespace EventService.Infrastructure.Domain.ExhibitionProposals;

public class ExhibitionProposalRepository : IExhibitionProposalRepository
{
    private readonly EventsContext _context;

    public ExhibitionProposalRepository(EventsContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ExhibitionProposal exhibitionProposal)
    {
        await _context.ExhibitionProposals.AddAsync(exhibitionProposal);
    }

    public async Task<ExhibitionProposal?> GetByIdAsync(ExhibitionProposalId exhibitionProposalId)
    {
        return await _context.ExhibitionProposals.FirstOrDefaultAsync(x => x.Id == exhibitionProposalId);
    }
}
