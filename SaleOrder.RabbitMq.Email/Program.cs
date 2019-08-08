using SaleOrder.RabbitMq.Domain.Configuration.Structs;
using SaleOrder.RabbitMq.Infra.DI;
using SaleOrder.RabbitMq.Infra.Rabbit;
using SimpleInjector;
using System;

namespace SaleOrder.RabbitMq.Email
{
    class Program
    {
        static readonly Container container = DIBootStart.Container;

        static void Main(string[] args)
        {
            Console.WriteLine("Receiving Orders...... \n");

            var receiver = container.GetInstance<RabbitListener>();
            receiver.Subscribe(QueueType.Email, SendEmail);
        }

        private static void SendEmail(string message)
        {
            Console.WriteLine("Received and sent: {0}", message);
        }
    }
}
