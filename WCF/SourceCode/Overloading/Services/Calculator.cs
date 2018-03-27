
namespace WCF.Overloading.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Calculator" in both code and config file together.
    public class Calculator : ICalculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Add(double x, double y, double z)
        {
            return x + y + z;
        }
    }
}
