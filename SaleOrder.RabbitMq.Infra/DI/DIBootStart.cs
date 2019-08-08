using RabbitMQ.Client;
using SaleOrder.RabbitMq.Domain.Configuration.Interfaces;
using SaleOrder.RabbitMq.Infra.Rabbit;
using SaleOrder.RabbitMq.Infra.Repository;
using SimpleInjector;

namespace SaleOrder.RabbitMq.Infra.DI
{
    public static class DIBootStart
    {
        public static Container Container { get; private set; }

        static DIBootStart()
        {
            Container = new Container();
            Start();
        }

        static private void Start()
        {
            Container.Register<IConfigurationRepository, ConfigurationRepository>();
            Container.Register<IRabbitConnection<IModel>, RabbitConnection>();
            Container.Register<IRabbitSender, RabbitSender>();
            Container.Register<IRabbitListener, RabbitListener>();
            Container.Verify();
        }
    }
}
