using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQExample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQExample
{
    public class Consumer
    {
        private readonly RabbitMQService _rabbitMQService;

        public Consumer(string queueName)
        {
            _rabbitMQService = new RabbitMQService();

            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Person person = JsonConvert.DeserializeObject<Person>(message);

                        Console.WriteLine($" Adı: {person.Name} Soyadı:{person.SurName} [{person.Message}]");
                    };

                    channel.BasicConsume(queueName, false, consumer);
                    Console.ReadLine();
                }
            }
        }
    }
}
