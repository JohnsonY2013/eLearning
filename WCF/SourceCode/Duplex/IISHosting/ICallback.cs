using System.ServiceModel;

namespace WCF.Duplex.IISHosting
{
    public interface ICallback
    {
        [OperationContract(IsOneWay = true)]
        void DisplayResult(double x, double y, double result);
    }
}
