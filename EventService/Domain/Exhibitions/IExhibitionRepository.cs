namespace EventService.Domain.Exhibitions;

public interface IExhibitionRepository
{
    Task AddAsync(Exhibition exhibition);

    Task<int> Commit();

    Task<Exhibition> GetByIdAsync(ExhibitionId id);

    Task<IEnumerable<Exhibition>> GatAllAsync();
}