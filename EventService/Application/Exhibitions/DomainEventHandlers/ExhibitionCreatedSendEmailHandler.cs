using EventService.Application.Exhibitions.Commands.SendExhibitionCreatedEmail;
using EventService.Domain.Exhibitions.Events;
using MediatR;

namespace EventService.Application.Exhibitions.DomainEventHandlers;

public class ExhibitionCreatedSendEmailHandler : INotificationHandler<ExhibitionCreatedDomainEvent>
{
    private readonly IMediator _mediator;

    public ExhibitionCreatedSendEmailHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task Handle(ExhibitionCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        _ = _mediator.Send(new SendExhibitionCreatedEmailCommand(
                    Guid.NewGuid(),
                    notification.ExhibitionId,
                    notification.CreatorId), cancellationToken);
        return Task.CompletedTask;
    }
}