using System;
using System.ServiceModel;
using WCF.Exception.Client.CalculatorServices;

namespace WCF.Exception.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var client = new CalculatorServices.CalculatorClient())
            //{
            var client = new CalculatorServices.CalculatorClient();
            try
            {
                var result = client.Divide(10, 5);
                Console.WriteLine($"x / y = {result} when x = {10} y = {5}");

                result = client.Divide(2, 0);
                Console.WriteLine($"x / y = {result} when x = {2} y = {0}");
            }
            catch (FaultException<MathError> ex)
            {
                var error = ex.Detail;
                Console.WriteLine("An Fault is thrown.\n\tFault code:{0}\n\tFault Reason:{1}\n\tOperation:{2}\n\tMessage:{3}", ex.Code, ex.Reason, error.Operation, error.ErrorMessage);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("An Exception is thrown.\n\tException Type:{0}\n\tError Message:{1}", ex.GetType(), ex.Message);

            }

            // Now since the server side "bombed" out, the WCF runtime has "faulted" the channel 
            // - e.g. the communication link between the client and the server is unusable - after all, 
            // it looks like your server just blew up, so you cannot communicate with it any more.
            if (client.InnerChannel.State != System.ServiceModel.CommunicationState.Faulted)
            {
                (client as System.ServiceModel.ICommunicationObject).Close();
            }

            Console.ReadLine();
            //}
        }
    }
}
