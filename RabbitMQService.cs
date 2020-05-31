using RabbitMQ.Client;

namespace RabbitMQExample
{
    public class RabbitMQService
    {
        private readonly string _hostName = "localhost";
        private readonly string _userName = "admin";
        private readonly string _password = "123456";

        public IConnection GetRabbitMQConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                HostName = _hostName,
                UserName = _userName,
                Password = _password
            };

            return connectionFactory.CreateConnection();
        }
    }
}
