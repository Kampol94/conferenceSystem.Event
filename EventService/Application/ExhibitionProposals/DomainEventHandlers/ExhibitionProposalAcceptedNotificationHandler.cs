using EventService.Application.Exhibitions.Commands.CreateNewExhibition;
using EventService.Domain.ExhibitionProposals.Events;
using MediatR;

namespace EventService.Application.ExhibitionProposals.DomainEventHandlers;

public class ExhibitionProposalAcceptedNotificationHandler : INotificationHandler<ExhibitionProposalAcceptedDomainEvent>
{
    private readonly IMediator _mediator;

    public ExhibitionProposalAcceptedNotificationHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(ExhibitionProposalAcceptedDomainEvent notification, CancellationToken cancellationToken)
    {
        _ = await _mediator.Send(
            new CreateNewExhibitionCommand(
                Guid.NewGuid(),
                notification.ExhibitionProposalId), cancellationToken);
    }
}