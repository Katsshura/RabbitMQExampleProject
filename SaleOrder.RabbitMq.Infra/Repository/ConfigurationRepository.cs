using SaleOrder.RabbitMq.Domain.Configuration.Interfaces;
using SaleOrder.RabbitMq.Domain.Configuration.Structs;
using System;

namespace SaleOrder.RabbitMq.Infra.Repository
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        public string HostName { get; private set; }
        public string Exchange { get; private set; }

        public ConfigurationRepository()
        {
            HostName = "localhost";
            Exchange = "SaleOrder";
        }
        public string GetRoutingKey(QueueType queueType)
        {
            switch (queueType)
            {
                case QueueType.Email:
                    return "email_order";
                case QueueType.Error:
                    return "error_order";
                case QueueType.Log:
                    return "log_order";
                case QueueType.Order:
                    return "order";
                default:
                    throw new Exception("Bad request -> Type is not valid");
            }
        }
    }
}
