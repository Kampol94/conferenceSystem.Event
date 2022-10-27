using EventService.Application.Contracts;
using EventService.Application.IntegrationEvents.EventHandlings;
using MediatR;

namespace EventService.API;

public static class EventsBusStartup
{
    public static void Initialize(IEventBus eventBus, IMediator mediator)
    {
        eventBus.Subscribe(new EventFeePaidIntegrationEventHandler(mediator));
        eventBus.Subscribe(new ExhibitionProposalAcceptedIntegrationEventHandler(mediator));
        eventBus.Subscribe(new NewUserRegisteredIntegrationEventHandler(mediator));
        eventBus.Subscribe(new SubscriptionExpirationDateChangedIntegrationEventHandler(mediator));
    }
}
