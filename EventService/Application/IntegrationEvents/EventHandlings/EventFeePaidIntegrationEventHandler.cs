using EventService.Application.ConferenceSubscriptions.Commands.ChangeSubscriptionExpirationDateForMember;
using EventService.Application.Contracts;
using EventService.Application.Events.Commands.MarkEventParticipantFeeAsPayed;
using EventService.Application.IntegrationEvents.Events;
using EventService.Domain.Members;
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
        var command = new MarkEventParticipantFeeAsPayedCommand(
            Guid.NewGuid(),
            @event.PayerId,
            @event.MeetingId);
        await _mediator.Send(command);
    }
}