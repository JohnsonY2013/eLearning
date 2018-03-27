using System.ServiceModel;

namespace WCF.Overloading.Client
{
    [ServiceContract(Name = "ICalculator")]
    public interface IMyCalculator
    {
        [OperationContract(Name = "AddWithTwoOperands")]
        double Add(double x, double y);

        [OperationContract(Name = "AddWithThreeOperands")]
        double Add(double x, double y, double z);
    }
}
