using EventService.Domain.Contracts;

namespace EventService.Domain.Members.Events;

public class MemberCreatedDomainEvent : DomainEventBase
{
    public MemberId MemberId { get; }

    public MemberCreatedDomainEvent(MemberId memberId)
    {
        MemberId = memberId;
    }
}