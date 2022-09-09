using EventService.Domain.Exhibitions;
using Microsoft.EntityFrameworkCore;

namespace EventService.Infrastructure.Domain.Exhibitions;

public class ExhibitionRepository : IExhibitionRepository
{
    private readonly EventsContext _meetingsContext;

    public ExhibitionRepository(EventsContext meetingsContext)
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
