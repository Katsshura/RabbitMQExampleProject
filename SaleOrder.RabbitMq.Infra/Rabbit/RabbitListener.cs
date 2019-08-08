using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SaleOrder.RabbitMq.Domain.Configuration.Interfaces;
using SaleOrder.RabbitMq.Domain.Configuration.Structs;
using System;
using System.Text;

namespace SaleOrder.RabbitMq.Infra.Rabbit
{
    public class RabbitListener : IRabbitListener
    {
        private IRabbitConnection<IModel> connection;
        private IModel channel;
        private IConfigurationRepository configuration;
        private int count = 0;

        public RabbitListener(IRabbitConnection<IModel> connection)
        {
            this.connection = connection;
            channel = this.connection.Channel;
            configuration = this.connection.Configuration;
        }


        public void Subscribe(QueueType type, Action<string> callback)
        {
            channel.BasicQos(0, 50, false);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                HandleMessage(model, ea, type, callback);
            };

            channel.BasicConsume(configuration.GetRoutingKey(type), false, consumer);
        }

        private void HandleMessage(object obj, BasicDeliverEventArgs eventArgs, QueueType type, Action<string> action)
        {
            string message = string.Empty;

            message = DecodeMessage(eventArgs.Body);

            count++;

            if (count % 3 == 0 && type == QueueType.Email)
            {
                channel.BasicNack(eventArgs.DeliveryTag, false, false);
            }
            else
            {
                action(message);
                channel.BasicAck(eventArgs.DeliveryTag, false);
            }
        }

        public string DecodeMessage(byte[] body)
        {
            return Encoding.UTF8.GetString(body);
        }
    }
}
