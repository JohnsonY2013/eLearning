using System;
using System.ServiceModel;

namespace WCF.Exception.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Calculator" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Calculator : ICalculator
    {
        public double Divide(double x, double y)
        {
            if (y == 0)
            {
                //throw new DivideByZeroException("Divide by Zero!");
                var error = new MathError("Divide", "Divide by Zero!");
                throw new FaultException<MathError>(error, new FaultReason("Parameters passed are not valid!"), new FaultCode("sender"));
            }

            return x / y;
        }

        public Calculator()
        {
            Console.WriteLine("Calculator has been created!");
        }

        ~Calculator()
        {
            Console.WriteLine("Calculator has been disposed!");
        }
    }
}
