using SaleOrder.RabbitMq.Domain.Configuration.Structs;
using System;

namespace SaleOrder.RabbitMq.Domain.Configuration.Interfaces
{
    public interface IRabbitListener
    {
        void Subscribe(QueueType type, Action<string> action);
        string DecodeMessage(byte[] body);
    }
}
