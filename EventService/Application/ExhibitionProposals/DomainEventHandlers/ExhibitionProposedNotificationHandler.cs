using CompanyName.MyMeetings.Modules.Meetings.Domain.ExhibitionProposals.Events;
using MediatR;

namespace EventService.Application.ExhibitionProposals.DomainEventHandlers;

public class ExhibitionProposedNotificationHandler : INotificationHandler<ExhibitionProposedDomainEvent>
{
    public Task Handle(ExhibitionProposedDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}