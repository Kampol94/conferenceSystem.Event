using EventService.Application.Contracts;

namespace EventService.Application.IntegrationEvents.Events;

public class SubscriptionExpirationDateChangedIntegrationEvent : IntegrationEvent
{
    public SubscriptionExpirationDateChangedIntegrationEvent(
        Guid id,
        DateTime occurredOn,
        Guid payerId,
        DateTime expirationDate)
        : base(id, occurredOn)
    {
        PayerId = payerId;
        ExpirationDate = expirationDate;
    }

    public Guid PayerId { get; }

    public DateTime ExpirationDate { get; }
}