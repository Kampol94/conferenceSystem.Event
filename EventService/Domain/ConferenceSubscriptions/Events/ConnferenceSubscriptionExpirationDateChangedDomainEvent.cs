using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.ConferenceSubscriptions.Events;

public class ConnferenceSubscriptionExpirationDateChangedDomainEvent : DomainEventBase
{
    public ConnferenceSubscriptionExpirationDateChangedDomainEvent(MemberId memberId, DateTime expirationDate)
    {
        MemberId = memberId;
        ExpirationDate = expirationDate;
    }

    public MemberId MemberId { get; }

    public DateTime ExpirationDate { get; }
}