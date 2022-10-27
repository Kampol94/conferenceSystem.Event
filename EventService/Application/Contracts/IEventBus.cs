namespace EventService.Application.Contracts;
public interface IEventBus
{
    void Consume();
    void Publish<T>(T @event) where T : IntegrationEvent;
    void Subscribe<U>(IServiceProvider services) where U : IntegrationEvent;
}