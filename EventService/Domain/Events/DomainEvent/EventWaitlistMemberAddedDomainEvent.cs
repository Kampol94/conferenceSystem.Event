﻿using EventService.Domain.Contracts;
using EventService.Domain.Members;

namespace EventService.Domain.Events.DomainEvent;

public class EventWaitlistMemberAddedDomainEvent : DomainEventBase
{
    public EventWaitlistMemberAddedDomainEvent(EventId eventId, MemberId memberId)
    {
        EventId = eventId;
        MemberId = memberId;
    }

    public EventId EventId { get; }

    public MemberId MemberId { get; }
}