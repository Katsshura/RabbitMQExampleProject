using RabbitMQ.Client;
using SaleOrder.RabbitMq.Domain.Configuration.Interfaces;
using SaleOrder.RabbitMq.Domain.Configuration.Structs;
using System;
using System.Text;

namespace SaleOrder.RabbitMq.Infra.Rabbit
{
    public class RabbitSender : IRabbitSender
    {
        private IRabbitConnection<IModel> connection;

        public RabbitSender(IRabbitConnection<IModel> connection)
        {
            this.connection = connection;
        }
        public void Add(string message, QueueType type)
        {
            if (!string.IsNullOrEmpty(message))
            {
                byte[] body = EncodeMessage(message);

                connection.Channel.BasicPublish(
                    exchange: connection.Configuration.Exchange,
                    routingKey: connection.Configuration.GetRoutingKey(type),
                    basicProperties: null,
                    body: body);

                Console.WriteLine("[X] Sent message!");
            }
        }

        public byte[] EncodeMessage(string message)
        {
            return Encoding.UTF8.GetBytes(message);
        }
    }
}
