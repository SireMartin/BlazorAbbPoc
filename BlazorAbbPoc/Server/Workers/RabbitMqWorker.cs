using BlazorAbbPoc.Server.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace BlazorAbbPoc.Server.Workers;


public class RabbitMqWorker : BackgroundService
{
    private readonly IPlcMsgDispatcher _plcMsgDispatcher;

    public RabbitMqWorker(IPlcMsgDispatcher plcMsgDispatcher)
    {
        _plcMsgDispatcher = plcMsgDispatcher;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.Run(() =>
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "amq.topic", type: "topic", durable: true);
                var queueName = channel.QueueDeclare(queue: "dotnet_reader", durable: true, exclusive: false, autoDelete: false).QueueName;

                var args = new[] { "#" };

                foreach (var bindingKey in args)
                {
                    channel.QueueBind(queue: queueName,
                                      exchange: "amq.topic",
                                      routingKey: bindingKey);
                }

                Console.WriteLine(" [*] Waiting for messages. To exit press CTRL+C");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var routingKey = ea.RoutingKey;
                    Console.WriteLine(" [x] Received '{0}':'{1}'",
                                      routingKey,
                                      message);
                    var plcMsg = JsonSerializer.Deserialize<Shared.Plc.AbbPlcMsg?>(message);
                    _plcMsgDispatcher.DispatchPlcMsg(plcMsg);
                };
                channel.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumer: consumer);
            }
        });
    }
}
