using System;
using System.ServiceModel.Activation;

namespace WCF.REST.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Time : ITime
    {

        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
