using EventService.Application.ConferenceSubscriptions.Commands.ChangeSubscriptionExpirationDateForMember;
using EventService.Application.Contracts;
using EventService.Application.ExhibitionProposals.Commands.AcceptExhibitionProposal;
using EventService.Application.IntegrationEvents.Events;
using EventService.Application.Members.CreateMember;
using EventService.Domain.Members;
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
        var command = new CreateMemberCommand(
            Guid.NewGuid(),
            @event.UserId,
            @event.Login,
            @event.Email,
            @event.FirstName,
            @event.LastName,
            @event.Name);
        await _mediator.Send(command);
    }
}