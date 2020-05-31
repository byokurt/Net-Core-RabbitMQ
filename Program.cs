using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQExample.Models;
using System;
using System.Text;

namespace RabbitMQExample
{
    class Program
    {
        private static readonly string _queueName = "OSMANKURT";
        private static Publisher _publisher;
        private static Consumer _consumer;

        static void Main(string[] args)
        {
            Person person = new Person() { Name = "Osman", SurName = "KURT", ID = 1, BirthDate = new DateTime(1953, 8, 3), Message = "osmankurt.net" };

            _publisher = new Publisher(_queueName, person);

            _consumer = new Consumer(_queueName);
        }
    }
}
