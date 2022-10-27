using EventService.Application.Contracts;
using EventService.Application.ExhibitionProposals.Commands.AcceptExhibitionProposal;
using EventService.Application.IntegrationEvents.Events;
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
        AcceptExhibitionProposalCommand command = new(
            Guid.NewGuid(),
            @event.ExhibitionProposalId);
        _ = await _mediator.Send(command);
    }
}