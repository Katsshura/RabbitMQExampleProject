using System;
using System.Collections.Generic;
using System.Text;

namespace SaleOrder.RabbitMq.Domain.Configuration.Structs
{
    public enum QueueType
    {
        Email,
        Error,
        Log,
        Order
    }
}
