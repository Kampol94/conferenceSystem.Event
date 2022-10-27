using EventService.Application.Contracts;
using EventService.Domain.Contracts;

namespace EventService.Infrastructure.Domain;

public class Repository : IRepository
{
    private readonly EventsContext _context;

    public Repository(EventsContext context)
    {
        _context = context;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public List<BaseEntity> GetEntitiesWithEvents()
    {
        return _context.ChangeTracker
                .Entries<BaseEntity>()
                .Where(x => x.Entity.CountEvents != 0)
                .Select(x => x.Entity)
                .ToList();
    }
}
