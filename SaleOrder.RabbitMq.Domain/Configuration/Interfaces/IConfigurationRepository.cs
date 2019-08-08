using SaleOrder.RabbitMq.Domain.Configuration.Structs;

namespace SaleOrder.RabbitMq.Domain.Configuration.Interfaces
{
    public interface IConfigurationRepository
    {
        string HostName { get; }
        string Exchange { get; }

        string GetRoutingKey(QueueType queueType);
    }
}
