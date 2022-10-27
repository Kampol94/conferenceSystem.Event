using EventService.Application.Contracts;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace EventService.Infrastructure.Services;

public class EventBus : IEventBus
{
    public void Publish<T>(T @event) where T : IntegrationEvent
    {
        //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
        ConnectionFactory factory = new()
        {
            HostName = "rabbitmq"
        };
        //Create the RabbitMQ connection using connection factory details as i mentioned above
        IConnection connection = factory.CreateConnection();
        //Here we create channel with session and model
        using
        IModel channel = connection.CreateModel();
        //declare the queue after mentioning name and a few property related to that
        _ = channel.QueueDeclare(typeof(T).Name, exclusive: false);
        //Serialize the message
        string json = JsonConvert.SerializeObject(@event);
        byte[] body = Encoding.UTF8.GetBytes(json);
        //put the data on to the product queue
        channel.BasicPublish(exchange: "", routingKey: typeof(T).Name, body: body);
    }

    public void Subscribe<T>(IIntegrationEventHandler<T> handler) where T : IntegrationEvent
    {
        ConnectionFactory factory = new()
        {
            HostName = "rabbitmq"
        };
        //Create the RabbitMQ connection using connection factory details as i mentioned above
        IConnection connection = factory.CreateConnection();
        //Here we create channel with session and model
        using
        IModel channel = connection.CreateModel();
        //declare the queue after mentioning name and a few property related to that
        _ = channel.QueueDeclare(typeof(T).Name, exclusive: false);
        //Set Event object which listen message from chanel which is sent by producer
        EventingBasicConsumer consumer = new(channel);
        consumer.Received += (model, eventArgs) =>
        {
            byte[] body = eventArgs.Body.ToArray();
            T? @event = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(body));
            _ = handler.Handle(@event);
            Console.WriteLine(@event);
        };
        //read the message
        _ = channel.BasicConsume(queue: typeof(T).Name, autoAck: true, consumer: consumer);
    }
}
