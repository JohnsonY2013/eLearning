using System;
using System.ServiceModel;
using System.Transactions;
using WCF.MSMQ.Models;

namespace WCF.MSMQ.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var channelFactory = new ChannelFactory<IOrderProcessor>("defaultEndpoint");
            var channel = channelFactory.CreateChannel();

            var order = new Order(Guid.NewGuid(), DateTime.Today, Guid.NewGuid(), "A Company");
            var orderItem = new OrderItem(Guid.NewGuid(), "PC", 5000, 20);
            order.OrderItems.Add(orderItem);
            orderItem = new OrderItem(Guid.NewGuid(), "Printer", 7000, 2);
            order.OrderItems.Add(orderItem);

            Console.WriteLine("Submit order to server");

            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                channel.Submit(order);
                scope.Complete();
            }
            Console.ReadLine();
        }
    }
}
