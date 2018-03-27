using System.ServiceModel;

namespace WCF.Duplex.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Calculator" in both code and config file together.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    //[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Calculator : ICalculator
    {
        public void Add(double x, double y)
        {
            var result = x + y;
            var callback = OperationContext.Current.GetCallbackChannel<ICallback>();
            callback.DisplayResult(x, y, result);
        }
    }
}
