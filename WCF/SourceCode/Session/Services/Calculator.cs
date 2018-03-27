using System;
using System.ServiceModel;

namespace WCF.Session.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Calculator" in both code and config file together.
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Calculator : ICalculator
    {
        private double _result;

        public void Adds(double x)
        {
            Console.WriteLine($"The Add method is invoked and the current session ID is:{OperationContext.Current.SessionId}");
            this._result += x;
        }

        public double GetResult()
        {
            Console.WriteLine($"The GetResult method is invoked and the current session ID is:{OperationContext.Current.SessionId}");
            return this._result;
        }

        public Calculator()
        {
            Console.WriteLine("Calculator object has been created.");
        }

        ~Calculator()
        {
            Console.WriteLine("Calculator object has been destroied.");
        }
    }
}
