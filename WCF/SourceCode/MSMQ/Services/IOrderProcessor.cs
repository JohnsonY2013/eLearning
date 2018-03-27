using System.ServiceModel;

namespace WCF.MSMQ.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IIOrderProcessor" in both code and config file together.
    [ServiceContract]
    [ServiceKnownType(typeof(Order))]
    public interface IOrderProcessor
    {
        [OperationContract(IsOneWay = true)]
        void Submit(Order order);
    }
}
