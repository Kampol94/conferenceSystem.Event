using System;
using System.Threading;
using System.Threading.Tasks;
using CompanyName.MyMeetings.Modules.Meetings.Application.Configuration.Commands;
using CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions.SendExhibitionCreatedEmail;
using MediatR;

namespace CompanyName.MyMeetings.Modules.Meetings.Application.Exhibitions;

internal class ExhibitionCreatedSendEmailHandler : INotificationHandler<ExhibitionCreatedNotification>
{
    private readonly ICommandsScheduler _commandsScheduler;

    public ExhibitionCreatedSendEmailHandler(ICommandsScheduler commandsScheduler)
    {
        _commandsScheduler = commandsScheduler;
    }

    public async Task Handle(ExhibitionCreatedNotification notification, CancellationToken cancellationToken)
    {
        await _commandsScheduler.EnqueueAsync(
            new SendExhibitionCreatedEmailCommand(
                Guid.NewGuid(),
                notification.DomainEvent.ExhibitionId,
                notification.DomainEvent.CreatorId));
    }
}