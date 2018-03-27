using System.ServiceModel;

namespace WCF.Duplex.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICalculator" in both code and config file together.
    [ServiceContract(Namespace = "http://www.digitcyber.com/",
        CallbackContract = typeof(ICallback))]
    public interface ICalculator
    {
        [OperationContract(IsOneWay = true)]
        void Add(double x, double y);
    }
}
