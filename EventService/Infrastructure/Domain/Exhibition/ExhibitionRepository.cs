using EventService.Domain.Exhibitions;
using EventService.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CompanyName.MyMeetings.Modules.Meetings.Infrastructure.Domain.MeetingGroups;

internal class ExhibitionRepository : IExhibitionRepository
{
    private readonly EventsContext _meetingsContext;

    internal ExhibitionRepository(EventsContext meetingsContext)
    {
        _meetingsContext = meetingsContext;
    }

    public async Task AddAsync(Exhibition exhibition)
    {
        await _meetingsContext.Exhibitions.AddAsync(exhibition);
    }

    public async Task<int> Commit()
    {
        return await _meetingsContext.SaveChangesAsync();
    }

    public IQueryable<Exhibition> GatAllAsync()
    {
        return _meetingsContext.Exhibitions;
    }

    public async Task<Exhibition?> GetByIdAsync(ExhibitionId id)
    {
        return await _meetingsContext.Exhibitions.FirstOrDefaultAsync(x => x.Id == id);
    }
}
