using RabbitMQ.Client;
using SaleOrder.RabbitMq.Domain.Configuration.Interfaces;

namespace SaleOrder.RabbitMq.Infra.Rabbit
{
    public sealed class RabbitConnection : IRabbitConnection<IModel>
    {
        public IModel Channel { get; private set; }
        public IConfigurationRepository Configuration { get; set; }

        private ConnectionFactory factory;
        private IConnection connection;

        public RabbitConnection(IConfigurationRepository configuration)
        {
            Configuration = configuration;
            Start();
        }

        private void Start()
        {
            factory = new ConnectionFactory() { HostName = Configuration.HostName };
            connection = factory.CreateConnection();
            Channel = connection.CreateModel();
        }
    }
}
