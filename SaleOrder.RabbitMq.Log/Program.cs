using SaleOrder.RabbitMq.Domain.Configuration.Structs;
using SaleOrder.RabbitMq.Infra.DI;
using SaleOrder.RabbitMq.Infra.Rabbit;
using SimpleInjector;
using System;

namespace SaleOrder.RabbitMq.Log
{
    class Program
    {
        static readonly Container container = DIBootStart.Container;

        static void Main(string[] args)
        {
            Console.WriteLine("Receiving Logs...... \n");

            var receiver = container.GetInstance<RabbitListener>();
            receiver.Subscribe(QueueType.Log, LogMessage);
        }

        private static void LogMessage(string message)
        {
            Console.WriteLine("Logging: {0}", message);
        }
    }
}
