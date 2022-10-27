using EventService.Domain.Contracts;

namespace EventService.Application.Contracts;
public interface IRepository
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
    List<BaseEntity> GetEntitiesWithEvents();
}
