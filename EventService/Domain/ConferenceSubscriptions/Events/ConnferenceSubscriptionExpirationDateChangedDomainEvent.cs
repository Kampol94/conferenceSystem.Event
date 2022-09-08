using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.ConferenceSubscriptions.Events;

public class ConferenceSubscriptionExpirationDateChangedDomainEvent : DomainEventBase
{
    public ConferenceSubscriptionExpirationDateChangedDomainEvent(MemberId memberId, DateTime expirationDate)
    {
        MemberId = memberId;
        ExpirationDate = expirationDate;
    }

    public MemberId MemberId { get; }

    public DateTime ExpirationDate { get; }
}