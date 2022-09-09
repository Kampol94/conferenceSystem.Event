using EventService.Domain.ConferenceSubscriptions;

namespace EventService.Infrastructure.Domain.ConferenceSubscriptions;

public class ConferenceSubscriptionRepository : IConferenceSubscriptionRepository
{
    private readonly EventsContext _meetingsContext;

    public ConferenceSubscriptionRepository(EventsContext meetingsContext)
    {
        _meetingsContext = meetingsContext;
    }

    public async Task AddAsync(ConferenceSubscription member)
    {
        await _meetingsContext.ConferenceSubscriptions.AddAsync(member);
    }

    public async Task<ConferenceSubscription?> GetByIdOptionalAsync(ConferenceSubscriptionId memberSubscriptionId)
    {
        return await _meetingsContext.ConferenceSubscriptions.FindAsync(memberSubscriptionId);
    }
}