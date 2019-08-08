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
            List<string> orders = new List<string>();
            Console.WriteLine("Generating Orders...... \n");

            orders.Add("{'orderId': 1,  'user': 'Fulano1',  'email': 'fulano1@fulano.com'}");
            orders.Add("{'orderId': 2,  'user': 'Fulano2',  'email': 'fulano2@fulano.com'}");
            orders.Add("{'orderId': 3,  'user': 'Fulano3',  'email': 'fulano3@fulano.com'}");
            orders.Add("{'orderId': 4,  'user': 'Fulano4',  'email': 'fulano4@fulano.com'}");
            orders.Add("{'orderId': 5,  'user': 'Fulano5',  'email': 'fulano5@fulano.com'}");
            orders.Add("{'orderId': 6,  'user': 'Fulano6',  'email': 'fulano6@fulano.com'}");
            orders.Add("{'orderId': 7,  'user': 'Fulano7',  'email': 'fulano7@fulano.com'}");
            orders.Add("{'orderId': 8,  'user': 'Fulano8',  'email': 'fulano8@fulano.com'}");
            orders.Add("{'orderId': 9,  'user': 'Fulano9',  'email': 'fulano9@fulano.com'}");

            Console.WriteLine("Sending to Rabbit.........\n");

            var sender = container.GetInstance<RabbitSender>();
            orders.ForEach((item) => { sender.Add(item, QueueType.Order); });
        }
    }
}
