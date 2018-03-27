using System;
using System.Runtime.Serialization;

namespace WCF.MSMQ.Services
{
    [DataContract]
    public class OrderItem
    {
        public OrderItem() { }

        public OrderItem(Guid productId, string productName, decimal unitPrice, int quantity)
        {
            ProductID = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        #region Public Properties

        [DataMember]
        public Guid ProductID { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public decimal UnitPrice { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        #endregion
    }
}
