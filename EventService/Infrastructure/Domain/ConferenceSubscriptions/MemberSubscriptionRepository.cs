using EventService.Domain.ConferenceSubscriptions;
using EventService.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CompanyName.MyMeetings.Modules.Meetings.Infrastructure.Domain.Members.MemberSubscriptions;

internal class ConferenceSubscriptionRepository : IConferenceSubscriptionRepository
{
    private readonly EventsContext _meetingsContext;

    internal ConferenceSubscriptionRepository(EventsContext meetingsContext)
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