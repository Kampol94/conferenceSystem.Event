using Microsoft.Extensions.Hosting;
using EventService.Application.Contracts;

namespace EventService.Infrastructure.Services;
public class EventReceiverService : BackgroundService
{
    private readonly IEventBus _eventBus;

    public EventReceiverService(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _eventBus.Consume();

        return Task.CompletedTask;
    }
}
