using EventService.Domain.Contracts;

namespace EventService.Domain.ConferenceSubscriptions;

public class ConferenceSubscriptionId : IdValueBase
{
    public ConferenceSubscriptionId(Guid value)
        : base(value)
    {
    }
}