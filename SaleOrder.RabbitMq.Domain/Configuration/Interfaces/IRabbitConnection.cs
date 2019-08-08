namespace SaleOrder.RabbitMq.Domain.Configuration.Interfaces
{
    public interface IRabbitConnection<T>
    {
        T Channel { get; }
        IConfigurationRepository Configuration { get; }
    }
}
