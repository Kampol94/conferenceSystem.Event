using EventService.Domain.Contracts;

namespace EventService.Domain.Exhibitions;

public class ExhibitionId : IdValueBase
{
    public ExhibitionId(Guid value) : base(value)
    {
    }
}