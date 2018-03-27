using System;
using System.Runtime.Serialization;

namespace WCF.Serialization.SerializeTest
{
    [DataContract(Name = "Product", Namespace = "http://www.digitcyber.come/sample/product")]
    public class DataContractProduct
    {
        #region Private Fields

        private Guid _productID;
        private string _productName;
        private string _producingArea;
        private double _unitPrice;

        #endregion

        #region Constructors

        public DataContractProduct()
        {
            Console.WriteLine("The constructor of DataContractProduct has been invocated!");
        }

        public DataContractProduct(Guid id, string name, string producingArea, double price)
        {
            this._productID = id;
            this._productName = name;
            this._producingArea = producingArea;
            this._unitPrice = price;
        }

        #endregion

        #region Properties

        [DataMember(Name = "Id", Order = 1)]
        public Guid ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        [DataMember(Name = "Name", Order = 2)]
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        [DataMember(Name = "Area", Order = 3)]
        public string ProducingArea
        {
            get { return _producingArea; }
            set { _producingArea = value; }
        }

        [DataMember(Name = "Price", Order = 4)]
        public double UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        public string Catalog
        {
            get; set;
        }

        [DataMember]
        private string Weight
        {
            get; set;
        }
        #endregion
    }
}
