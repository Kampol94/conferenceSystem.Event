using EventService.Application.Contracts;

namespace EventService.Application.IntegrationEvents.Events;

public class EventFeePaidIntegrationEvent : IntegrationEvent
{
    public EventFeePaidIntegrationEvent(
        Guid id,
        DateTime occurredOn,
        Guid payerId,
        Guid meetingId)
        : base(id, occurredOn)
    {
        PayerId = payerId;
        MeetingId = meetingId;
    }

    public Guid PayerId { get; }

    public Guid MeetingId { get; }
}