using System.ServiceModel;

namespace WCF.Overloading.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICalculator" in both code and config file together.
    [ServiceContract]
    public interface ICalculator
    {
        //[OperationContract]
        [OperationContract(Name = "AddWithTwoOperands")]
        double Add(double x, double y);

        //[OperationContract]
        [OperationContract(Name = "AddWithThreeOperands")]
        double Add(double x, double y, double z);
    }
}
