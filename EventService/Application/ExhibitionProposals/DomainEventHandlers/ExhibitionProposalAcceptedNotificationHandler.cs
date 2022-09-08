using EventService.Application.Exhibition.Commands.CreateNewExhibition;
using EventService.Domain.ExhibitionProposals.Events;
using MediatR;

namespace EventService.Application.ExhibitionProposals.DomainEventHandlers;

internal class ExhibitionProposalAcceptedNotificationHandler : INotificationHandler<ExhibitionProposalAcceptedDomainEvent>
{
    private readonly IMediator _mediator;

    internal ExhibitionProposalAcceptedNotificationHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(ExhibitionProposalAcceptedDomainEvent notification, CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new CreateNewExhibitionCommand(
                Guid.NewGuid(),
                notification.ExhibitionProposalId), cancellationToken);
    }
}