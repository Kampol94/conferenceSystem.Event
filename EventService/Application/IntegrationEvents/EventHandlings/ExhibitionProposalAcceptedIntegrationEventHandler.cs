using EventService.Application.ConferenceSubscriptions.Commands.ChangeSubscriptionExpirationDateForMember;
using EventService.Application.Contracts;
using EventService.Application.ExhibitionProposals.Commands.AcceptExhibitionProposal;
using EventService.Application.IntegrationEvents.Events;
using EventService.Domain.Members;
using MediatR;

namespace EventService.Application.IntegrationEvents.EventHandlings;

public class ExhibitionProposalAcceptedIntegrationEventHandler : IIntegrationEventHandler<ExhibitionProposalAcceptedIntegrationEvent>
{
    private readonly IMediator _mediator;

    public ExhibitionProposalAcceptedIntegrationEventHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(ExhibitionProposalAcceptedIntegrationEvent @event)
    {
        var command = new AcceptExhibitionProposalCommand(
            Guid.NewGuid(),
            @event.ExhibitionProposalId);
        await _mediator.Send(command);
    }
}