using System;
using System.Xml.Serialization;

namespace WCF.Serialization.SerializeTest
{
    [XmlRoot(Namespace = "http://www.digitcyber.come/sample/order")]
    public class XmlOrder
    {
        private Guid _orderID;
        private DateTime _orderDate;
        private XmlProduct _product;
        private int _quantity;

        #region Constructors

        public XmlOrder()
        {
            this._orderID = new Guid();
            this._orderDate = DateTime.MinValue;
            this._quantity = int.MinValue;

            Console.WriteLine("The constructor of XmlOrder has been invocated!");
        }

        public XmlOrder(Guid id, DateTime date, XmlProduct product, int quantity)
        {
            this._orderID = id;
            this._orderDate = date;
            this._product = product;
            this._quantity = quantity;
        }

        #endregion

        #region Properties

        [XmlElement(ElementName = "Id", Order = 1)]
        public Guid OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }

        [XmlElement(ElementName = "Date", Order = 2)]
        public DateTime OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }

        [XmlElement(ElementName = "Product", Order = 3)]
        public XmlProduct Product
        {
            get { return _product; }
            set { _product = value; }
        }

        [XmlElement(ElementName = "Quantity", Order = 4)]
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        #endregion

        public override string ToString()
        {
            return string.Format("ID: {0}\nDate:{1}\nProduct:\n\tID:{2}\n\tName:{3}\n\tProducing Area:{4}\n\tPrice:{5}\nQuantity:{6}",
                this._orderID, this._orderDate, this._product.ProductID, this._product.ProductName, this._product.ProducingArea, this._product.UnitPrice, this._quantity);
        }
    }
}
