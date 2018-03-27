using System;
using System.ServiceModel;

namespace WCF.MSMQ.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IOrderProcessor" in both code and config file together.
    public class OrderProcessor : IOrderProcessor
    {
        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        public void Submit(Order order)
        {
            Orders.Add(order);
            Console.WriteLine("Receive an order.");
            Console.WriteLine(order.ToString());
        }
    }
}
