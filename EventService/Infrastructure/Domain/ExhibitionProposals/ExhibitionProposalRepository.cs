using EventService.Domain.ExhibitionProposals;
using EventService.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CompanyName.MyMeetings.Modules.Meetings.Infrastructure.Domain.MeetingGroupProposals;

internal class ExhibitionProposalRepository : IExhibitionProposalRepository
{
    private readonly EventsContext _context;

    internal ExhibitionProposalRepository(EventsContext context)
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
