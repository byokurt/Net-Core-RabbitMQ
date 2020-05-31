using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQExample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQExample
{
    public class Publisher
    {
        private readonly RabbitMQService _rabbitMQService;

        public Publisher(string queueName, Person request)
        {
            _rabbitMQService = new RabbitMQService();

            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, false, null);

                    string message = JsonConvert.SerializeObject(request);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish("", queueName, null, Encoding.UTF8.GetBytes(message));

                    Console.WriteLine("{0} queue'su üzerine, \"{1}\" kişisinin mesajı yazıldı.", queueName, request.Name);
                }
            }
        }
    }
}
