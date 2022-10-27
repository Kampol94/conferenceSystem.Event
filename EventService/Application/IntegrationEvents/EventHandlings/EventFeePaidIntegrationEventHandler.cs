using EventService.Application.Contracts;
using EventService.Application.Events.Commands.MarkEventParticipantFeeAsPayed;
using EventService.Application.IntegrationEvents.Events;
using MediatR;

namespace EventService.Application.IntegrationEvents.EventHandlings;

public class EventFeePaidIntegrationEventHandler : IIntegrationEventHandler<EventFeePaidIntegrationEvent>
{
    private readonly IMediator _mediator;

    public EventFeePaidIntegrationEventHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(EventFeePaidIntegrationEvent @event)
    {
        MarkEventParticipantFeeAsPayedCommand command = new(
            Guid.NewGuid(),
            @event.PayerId,
            @event.MeetingId);
        _ = await _mediator.Send(command);
    }
}