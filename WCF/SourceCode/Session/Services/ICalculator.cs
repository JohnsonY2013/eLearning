using System.ServiceModel;

namespace WCF.Session.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICalculator" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required)]    
    public interface ICalculator
    {
        [OperationContract(IsOneWay = true, IsInitiating = true, IsTerminating = false)]
        void Adds(double x);

        [OperationContract(IsInitiating = false, IsTerminating = true)]
        double GetResult();
    }
}
