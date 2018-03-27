using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace WCF.Serialization.SerializeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //SerializeViaDataContractSerializer();
            //DeserializeViaDataContractSerializer();

            SerializeViaXmlSerializer();
            DeserializeViaXmlSerializer();
        }

        static string _basePath = @".\";
        static void SerializeViaDataContractSerializer()
        {
            var product = new DataContractProduct(Guid.NewGuid(), "Dell PC", "Xiamen FuJian", 4500);
            var order = new DataContractOrder(Guid.NewGuid(), DateTime.Today, product, 300);

            var filename = _basePath + "Order.DataContractSerializer.xml";
            using (var fs = new FileStream(filename, FileMode.Create))
            {
                var serializer = new DataContractSerializer(typeof(DataContractOrder));
                using (var writer = XmlDictionaryWriter.CreateTextWriter(fs))
                {
                    serializer.WriteObject(writer, order);
                }
            }

            Process.Start(filename);
        }

        static void DeserializeViaDataContractSerializer()
        {
            DataContractOrder order;
            var filename = _basePath + "Order.DataContractSerializer.xml";
            using (var fs = new FileStream(filename, FileMode.Open))
            {
                var serializer = new DataContractSerializer(typeof(DataContractOrder));
                using (var reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas()))
                {
                    order = serializer.ReadObject(reader) as DataContractOrder;
                }
            }

            Console.WriteLine(order);
            Console.Read();
        }

        static void SerializeViaXmlSerializer()
        {
            var product = new XmlProduct(Guid.NewGuid(), "Dell PC", "Xiamen FuJian", 4500);
            var order = new XmlOrder(Guid.NewGuid(), DateTime.Today, product, 300);

            var filename = _basePath + "Order.XmlSerializer.xml";
            using (var fs = new FileStream(filename, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(XmlOrder));
                using (var writer = XmlDictionaryWriter.CreateTextWriter(fs))
                {
                    serializer.Serialize(writer, order);
                }
            }

            Process.Start(filename);
        }

        static void DeserializeViaXmlSerializer()
        {
            XmlOrder order;
            var filename = _basePath + "Order.XmlSerializer.xml";
            using (var fs = new FileStream(filename, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(XmlOrder));
                using (var reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas()))
                {
                    order = serializer.Deserialize(reader) as XmlOrder;
                }
            }

            Console.WriteLine(order);
            Console.Read();
        }
    }
}
