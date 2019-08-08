using SaleOrder.RabbitMq.Domain.Configuration.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaleOrder.RabbitMq.Domain.Configuration.Interfaces
{
    public interface IRabbitSender
    {
        void Add(string message, QueueType type);
        byte[] EncodeMessage(string message);
    }
}
