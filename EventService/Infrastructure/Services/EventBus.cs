using EventService.Application.Contracts;
using EventService.Application.IntegrationEvents.EventHandlings;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

namespace EventService.Infrastructure.Services;

public class EventBus : IEventBus
{
    private readonly IModel _channel;
    private Dictionary<string, EventingBasicConsumer> _consumers = new();

    public EventBus(IMediator mediator)
    {
        ConnectionFactory factory = new()
        {
            HostName = "localhost"
        };
        //Create the RabbitMQ connection using connection factory details as i mentioned above
        IConnection connection = factory.CreateConnection();
        //Here we create channel with session and model  
        _channel = connection.CreateModel();
        Subscribe(new EventFeePaidIntegrationEventHandler(mediator));
        Subscribe(new ExhibitionProposalAcceptedIntegrationEventHandler(mediator));
        Subscribe(new NewUserRegisteredIntegrationEventHandler(mediator));
        Subscribe(new SubscriptionExpirationDateChangedIntegrationEventHandler(mediator));
        
    }

    public void Publish<T>(T @event) where T : IntegrationEvent
    {
        _channel.ExchangeDeclare(typeof(T).Name, ExchangeType.Fanout);
        //_channel.QueueDeclare(typeof(T).Name, exclusive: false);
        //Serialize the message
        string json = JsonConvert.SerializeObject(@event);
        byte[] body = Encoding.UTF8.GetBytes(json);
        //put the data on to the product queue
        _channel.BasicPublish(exchange: typeof(T).Name, routingKey: "", body: body);
    }

    public void Subscribe<T>(IIntegrationEventHandler<T> handler) where T : IntegrationEvent
    {
        _channel.ExchangeDeclare(exchange: typeof(T).Name, type: ExchangeType.Fanout);
        var queueName = _channel.QueueDeclare(queue: "EventService_" + typeof(T).Name).QueueName;
        _channel.QueueBind(queue: queueName,
                              exchange: typeof(T).Name,
                              routingKey: "");
        //Set Event object which listen message from chanel which is sent by producer
        EventingBasicConsumer consumer = new(_channel);
        consumer.Received += (model, eventArgs) =>
        {
            byte[] body = eventArgs.Body.ToArray();
            T? @event = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(body));
            _ = handler.Handle(@event);
        };
        _consumers.Add(queueName, consumer);
    }

    public void Consume()
    {
        foreach (var consumer in _consumers)
        {
            _channel.BasicConsume(queue: consumer.Key, autoAck: true, consumer: consumer.Value);
        }
    }
}
