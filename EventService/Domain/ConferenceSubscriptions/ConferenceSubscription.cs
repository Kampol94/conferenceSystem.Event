using EventService.Domain.ConferenceSubscriptions.Events;
using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.ConferenceSubscriptions;

public class ConferenceSubscription : BaseEntity
{
    public ConferenceSubscriptionId Id { get; private set; }

    private DateTime _expirationDate;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private ConferenceSubscription()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    private ConferenceSubscription(MemberId memberId, DateTime expirationDate)
    {
        Id = new ConferenceSubscriptionId(memberId.Value);
        _expirationDate = expirationDate;

        this.AddDomainEvent(new ConnferenceSubscriptionExpirationDateChangedDomainEvent(memberId, _expirationDate));
    }

    public static ConferenceSubscription CreateForMember(MemberId memberId, DateTime expirationDate)
    {
        return new ConferenceSubscription(memberId, expirationDate);
    }

    public void ChangeExpirationDate(DateTime expirationDate)
    {
        _expirationDate = expirationDate;

        this.AddDomainEvent(new ConnferenceSubscriptionExpirationDateChangedDomainEvent(
            new MemberId(Id.Value),
            _expirationDate));
    }
}