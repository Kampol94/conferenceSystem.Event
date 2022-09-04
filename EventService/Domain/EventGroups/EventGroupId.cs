using EventService.Domain.Contracts;

namespace EventService.Domain.EventGroups;

internal class EventGroupId : ValueObject
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}