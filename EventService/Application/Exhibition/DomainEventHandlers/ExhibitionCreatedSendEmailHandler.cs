using EventService.Application.Exhibition.Commands.SendExhibitionCreatedEmail;
using EventService.Domain.Exhibitions.Events;
using MediatR;

namespace EventService.Application.Exhibition.DomainEventHandlers;

internal class ExhibitionCreatedSendEmailHandler : INotificationHandler<ExhibitionCreatedDomainEvent>
{
    private readonly IMediator _mediator;

    public ExhibitionCreatedSendEmailHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task Handle(ExhibitionCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        _mediator.Send(new SendExhibitionCreatedEmailCommand(
                    Guid.NewGuid(),
                    notification.ExhibitionId,
                    notification.CreatorId), cancellationToken);
        return Task.CompletedTask;
    }
}