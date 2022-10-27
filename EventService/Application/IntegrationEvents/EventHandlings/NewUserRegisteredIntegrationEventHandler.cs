using EventService.Application.Contracts;
using EventService.Application.IntegrationEvents.Events;
using EventService.Application.Members.CreateMember;
using MediatR;

namespace EventService.Application.IntegrationEvents.EventHandlings;

public class NewUserRegisteredIntegrationEventHandler : IIntegrationEventHandler<NewUserRegisteredIntegrationEvent>
{
    private readonly IMediator _mediator;

    public NewUserRegisteredIntegrationEventHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(NewUserRegisteredIntegrationEvent @event)
    {
        CreateMemberCommand command = new(
            Guid.NewGuid(),
            @event.UserId,
            @event.Login,
            @event.Email,
            @event.FirstName,
            @event.LastName,
            @event.Name);
        _ = await _mediator.Send(command);
    }
}