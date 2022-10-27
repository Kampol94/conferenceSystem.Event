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
        var factory = new ConnectionFactory
        {
            HostName = "rabbitmq"
        };
        //Create the RabbitMQ connection using connection factory details as i mentioned above
        var connection = factory.CreateConnection();
        //Here we create channel with session and model
        using
        var channel = connection.CreateModel();
        //declare the queue after mentioning name and a few property related to that
        channel.QueueDeclare(typeof(T).Name, exclusive: false);
        //Serialize the message
        var json = JsonConvert.SerializeObject(@event);
        var body = Encoding.UTF8.GetBytes(json);
        //put the data on to the product queue
        channel.BasicPublish(exchange: "", routingKey: typeof(T).Name, body: body);
    }

    public void Subscribe<T>(IIntegrationEventHandler<T> handler) where T : IntegrationEvent
    {
        var factory = new ConnectionFactory
        {
            HostName = "rabbitmq"
        };
        //Create the RabbitMQ connection using connection factory details as i mentioned above
        var connection = factory.CreateConnection();
        //Here we create channel with session and model
        using
        var channel = connection.CreateModel();
        //declare the queue after mentioning name and a few property related to that
        channel.QueueDeclare(typeof(T).Name, exclusive: false);
        //Set Event object which listen message from chanel which is sent by producer
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var @event = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(body));
            handler.Handle(@event);
            Console.WriteLine(@event);
        };
        //read the message
        channel.BasicConsume(queue: typeof(T).Name, autoAck: true, consumer: consumer);
    }
}
