using System;
using System.Collections.Generic;

namespace WCF.MSMQ.Models
{
    public static class Orders
    {
        private static IDictionary<Guid, Order> _orderList = new Dictionary<Guid, Order>();

        public static void Add(Order order)
        {
            _orderList.Add(order.OrderNo, order);
        }

        public static Order GetOrder(Guid orderNo)
        {
            return _orderList[orderNo];
        }
    }
}
