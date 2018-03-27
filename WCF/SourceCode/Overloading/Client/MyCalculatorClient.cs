using System.ServiceModel;

namespace WCF.Overloading.Client
{
    public class MyCalculatorClient : ClientBase<IMyCalculator>, IMyCalculator
    {
        public double Add(double x, double y)
        {
            return this.Channel.Add(x, y);
        }

        public double Add(double x, double y, double z)
        {
            return this.Channel.Add(x, y, z);
        }
    }
}
