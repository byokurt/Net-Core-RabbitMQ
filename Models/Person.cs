using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQExample.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Message { get; set; }
    }
}
