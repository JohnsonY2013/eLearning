using WCF.MSMQ.Client2.OrderServices;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace WCF.MSMQ.Client2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new OrderProcessorClient())
            {
                var order = new Order
                {
                    SupplierID = Guid.NewGuid(),
                    OrderDate = DateTime.Today,
                    OrderNo = Guid.NewGuid(),
                    SupplierName = "A Company"
                };

                var orderList = new List<OrderItem>();
                var orderItem = new OrderItem
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "PC",
                    UnitPrice = 5000,
                    Quantity = 20
                };
                orderList.Add(orderItem);
                orderItem = new OrderItem
                {
                    ProductID = Guid.NewGuid(),
                    ProductName = "Printer",
                    UnitPrice = 7000,
                    Quantity = 2
                };
                orderList.Add(orderItem);
                order.OrderItems = orderList.ToArray();

                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    client.Submit(order);
                    scope.Complete();
                }
            }
        }
    }
}
