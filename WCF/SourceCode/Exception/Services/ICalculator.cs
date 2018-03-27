using System.ServiceModel;

namespace WCF.Exception.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICalculator" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ICalculator
    {
        [OperationContract]
        [FaultContract(typeof(MathError))]
        double Divide(double x, double y);
    }
}
