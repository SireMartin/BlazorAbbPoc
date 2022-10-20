using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace BlazorAbbPoc.Server.Workers;

public class Worker : BackgroundService
{
    private readonly Services.DataService _dataService;

    public Worker(Services.DataService dataService)
    {
        _dataService = dataService;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.Run(() =>
        {
            //var factory = new ConnectionFactory() { HostName = "192.168.150.89" };
            //using (var connection = factory.CreateConnection())
            //using (var channel = connection.CreateModel())
            //{
            //    channel.ExchangeDeclare(exchange: "amq.topic", type: "topic", durable: true);
            //    var queueName = channel.QueueDeclare(queue: "dotnet_reader", durable: true, exclusive: false, autoDelete: false).QueueName;

            //    var args = new [] { "#" };

            //    foreach (var bindingKey in args)
            //    {
            //        channel.QueueBind(queue: queueName,
            //                          exchange: "amq.topic",
            //                          routingKey: bindingKey);
            //    }

            //    Console.WriteLine(" [*] Waiting for messages. To exit press CTRL+C");

            //    var consumer = new EventingBasicConsumer(channel);
            //    consumer.Received += (model, ea) =>
            //    {
            //        var body = ea.Body.ToArray();
            //        var message = Encoding.UTF8.GetString(body);
            //        var routingKey = ea.RoutingKey;
            //        Console.WriteLine(" [x] Received '{0}':'{1}'",
            //                          routingKey,
            //                          message);
            //         _dataService.PlcData = JsonSerializer.Deserialize<Shared.PlcData?>(message);
            //    };
            //    channel.BasicConsume(queue: queueName,
            //                         autoAck: true,
            //                         consumer: consumer);
                while(true)
                {
                    Thread.Sleep(100);
                }
            //}
        });
    }
}
