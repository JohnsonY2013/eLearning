using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WCF.MSMQ.Models
{
    [DataContract]
    [KnownType(typeof(OrderItem))]
    public class Order
    {
        //private IList<OrderItem> _orderItems;

        public Order()
        {
            //this._orderItems = new List<OrderItem>();
            OrderItems = new List<OrderItem>();
        }

        public Order(Guid orderNo, DateTime orderDate, Guid supplierID, string supplierName)
        {
            OrderNo = orderNo;
            OrderDate = OrderDate;
            SupplierID = supplierID;
            SupplierName = supplierName;

            OrderItems = new List<OrderItem>();
        }

        #region Public Properties

        [DataMember]
        public Guid OrderNo { get; set; }

        [DataMember]
        public DateTime OrderDate { get; set; }

        [DataMember]
        public Guid SupplierID { get; set; }

        [DataMember]
        public string SupplierName { get; set; }

        [DataMember]
        public IList<OrderItem> OrderItems
        {
            get; set;
        }

        #endregion

        #region Publis Methods

        public override string ToString()
        {
            var description = $"General Informaion:" +
                $"\n\tOrder No.\t: {OrderNo}" +
                $"\n\tOrder Date\t: {OrderDate}" +
                $"\n\tSupplier No.\t: {SupplierID}" +
                $"\n\tSupplier Name\t: {SupplierName}";

            var productList = new StringBuilder();
            productList.AppendLine("\nProducts:");

            var index = 0;
            foreach (var item in OrderItems)
            {
                productList.AppendLine($"\n{++index}. \tNo.\t\t: {item.ProductID}" +
                    $"\n\tName\t\t: {item.ProductName}" +
                    $"\n\tPrice\t\t: {item.UnitPrice}" +
                    $"\n\tQuantity\t: {item.Quantity}");
            }

            return description + productList.ToString();
        }

        #endregion
    }
}
