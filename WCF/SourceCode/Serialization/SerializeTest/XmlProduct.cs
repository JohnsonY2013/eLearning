using System;
using System.Xml.Serialization;

namespace WCF.Serialization.SerializeTest
{
    [XmlRoot(Namespace = "http://www.digitcyber.come/sample/product")]
    public class XmlProduct
    {
        #region Private Fields

        private Guid _productID;
        private string _productName;
        private string _producingArea;
        private double _unitPrice;

        #endregion

        #region Constructors

        public XmlProduct()
        {
            Console.WriteLine("The constructor of XmlProduct has been invocated!");
        }

        public XmlProduct(Guid id, string name, string producingArea, double price)
        {
            this._productID = id;
            this._productName = name;
            this._producingArea = producingArea;
            this._unitPrice = price;
        }

        #endregion

        #region Properties

        //[XmlElement(ElementName = "Id", Order = 1)]
        [XmlAttribute(AttributeName = "Id")]
        public Guid ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        [XmlElement(ElementName = "Name", Order = 1)]
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        [XmlElement(ElementName = "ProducingArea", Order = 2)]
        public string ProducingArea
        {
            get { return _producingArea; }
            set { _producingArea = value; }
        }

        [XmlElement(ElementName = "Price", Order = 3)]
        public double UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        //public string Catalog
        //{
        //    get; set;
        //}
        private string Weight
        {
            get; set;
        }
        #endregion
    }
}
