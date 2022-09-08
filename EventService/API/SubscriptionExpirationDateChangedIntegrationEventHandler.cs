namespace CompanyName.MyMeetings.Modules.Meetings.Application.ConferenceSubscriptions
{
    // public class SubscriptionExpirationDateChangedIntegrationEventHandler : INotificationHandler<SubscriptionExpirationDateChangedIntegrationEvent>
    // {
    //     private readonly ICommandsScheduler _commandsScheduler;

    //     public SubscriptionExpirationDateChangedIntegrationEventHandler(ICommandsScheduler commandsScheduler)
    //     {
    //         _commandsScheduler = commandsScheduler;
    //     }

    //     public async Task Handle(SubscriptionExpirationDateChangedIntegrationEvent @event, CancellationToken cancellationToken)
    //     {
    //         await _commandsScheduler.EnqueueAsync(new ChangeSubscriptionExpirationDateForParticipantCommand(
    //             Guid.NewGuid(),
    //             new ParticipantId(@event.PayerId),
    //             @event.ExpirationDate));
    //     }
    // }
}