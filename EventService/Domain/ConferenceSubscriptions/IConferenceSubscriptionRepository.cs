namespace EventService.Domain.ConferenceSubscriptions;

public interface IConferenceSubscriptionRepository
{
    Task<ConferenceSubscription> GetByIdOptionalAsync(ConferenceSubscriptionId conferenceSubscriptionId);

    Task AddAsync(ConferenceSubscription conferenceSubscriptionId);
}