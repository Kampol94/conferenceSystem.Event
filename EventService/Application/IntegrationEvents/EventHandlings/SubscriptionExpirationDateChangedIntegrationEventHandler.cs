using EventService.Application.ConferenceSubscriptions.Commands.ChangeSubscriptionExpirationDateForMember;
using EventService.Application.Contracts;
using EventService.Application.IntegrationEvents.Events;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.IntegrationEvents.EventHandlings;

public class SubscriptionExpirationDateChangedIntegrationEventHandler : IIntegrationEventHandler<SubscriptionExpirationDateChangedIntegrationEvent>
{
    private readonly IMediator _mediator;

    public SubscriptionExpirationDateChangedIntegrationEventHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(SubscriptionExpirationDateChangedIntegrationEvent @event)
    {
        var command = new ChangeSubscriptionExpirationDateForMemberCommand(
            Guid.NewGuid(),
            @event.PayerId,
            @event.ExpirationDate);
        await _mediator.Send(command);
    }
}