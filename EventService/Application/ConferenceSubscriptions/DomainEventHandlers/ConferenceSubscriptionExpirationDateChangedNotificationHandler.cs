using Dapper;
using EventService.Application.Exhibition.Commands;
using EventService.Domain.ConferenceSubscriptions.Events;
using EventService.Domain.Exhibitions;
using MediatR;
using System.Linq;

namespace EventService.Application.ConferenceSubscriptions.DomainEventHandlers;

public class ConferenceSubscriptionExpirationDateChangedNotificationHandler :
    INotificationHandler<ConferenceSubscriptionExpirationDateChangedDomainEvent>
{
    private readonly IExhibitionRepository _exhibitionRepository;
    private readonly IMediator _mediator;

    public ConferenceSubscriptionExpirationDateChangedNotificationHandler(IExhibitionRepository exhibitionRepository, IMediator mediator)
    {
        _exhibitionRepository = exhibitionRepository;
        _mediator = mediator;
    }

    public async Task Handle(ConferenceSubscriptionExpirationDateChangedDomainEvent notification, CancellationToken cancellationToken)
    {
        var exhibitionsCoveredByConferenceSubscription = (await _exhibitionRepository.GatAllAsync()).Where(x => x.CreatorId == notification.MemberId);

        foreach (var exhibition in exhibitionsCoveredByConferenceSubscription)
        {
            await _mediator.Send(new SetExhibitionExpirationDateCommand(
                Guid.NewGuid(),
                exhibition.Id,
                notification.ExpirationDate
            ));
        }
    }
}
