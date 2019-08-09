using SaleOrder.RabbitMq.Domain.Configuration.Structs;
using SaleOrder.RabbitMq.Infra.DI;
using SaleOrder.RabbitMq.Infra.Rabbit;
using SimpleInjector;
using System;
using System.Collections.Generic;

namespace SaleOrder.RabbitMq.Order
{
    class Program
    {
        static readonly Container container = DIBootStart.Container;
        static void Main(string[] args)
        {
            string order = string.Empty;

            Console.WriteLine("Generating Orders...... \n");

            var sender = container.GetInstance<RabbitSender>();

            Console.WriteLine("Sending to Rabbit.........\n");

            for (int i = 0; i < 1000000; i++)
            {
                order = "{'orderId': " + i + ",  'user': 'Fulano" + i + "',  'email': 'fulano" + i + "@fulano.com'}";
                sender.Add(order, QueueType.Order);
            }


        }
    }
}
