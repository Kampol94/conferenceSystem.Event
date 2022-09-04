using EventService.Domain.Contracts;

namespace EventService.Domain.ConferenceGroups;

internal class ConferenceGroupsId : IdValueBase
{
    protected ConferenceGroupsId(Guid value) : base(value)
    {
    }
}