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
        private IModel channel;
        private IConfigurationRepository configuration;
        private int count = 0;

        public RabbitListener(IRabbitConnection<IModel> connection)
        {
            channel = connection.Channel;
            configuration = connection.Configuration;
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

            //This if-else is only for forcing an error to test dead letter
            //Delete this if-else for a complete generic listener

            if (count % 3 == 0 && type == QueueType.Email)
            {
               //Rejects message, if dead letter is configured it will be send to it
                channel.BasicNack(eventArgs.DeliveryTag, false, false);
            }
            else
            {
                //Executes callback and removes it from queue with success status
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
