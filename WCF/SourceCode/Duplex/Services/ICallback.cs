using System.ServiceModel;

namespace WCF.Duplex.Services
{
    public interface ICallback
    {
        [OperationContract(IsOneWay = true)]
        void DisplayResult(double x, double y, double result);
    }
}
