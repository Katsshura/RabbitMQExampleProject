using SaleOrder.RabbitMq.Domain.Configuration.Structs;
using SaleOrder.RabbitMq.Infra.DI;
using SaleOrder.RabbitMq.Infra.Rabbit;
using SimpleInjector;
using System;

namespace SaleOrder.RabbitMq.Error
{
    class Program
    {
        static readonly Container container = DIBootStart.Container;

        static void Main(string[] args)
        {
            Console.WriteLine("Receiving Errors..... \n");

            var receiver = container.GetInstance<RabbitListener>();
            receiver.Subscribe(QueueType.Error, TryToFixError);
        }

        private static void TryToFixError(string error)
        {
            Console.WriteLine("Resolving Error: {0}", error);
        }
    }
}
