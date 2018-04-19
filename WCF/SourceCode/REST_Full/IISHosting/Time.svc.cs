using System;
using System.ServiceModel.Activation;

namespace WCF.REST.Hosting
{
    /// <summary>
    /// http://www.cnblogs.com/artech/archive/2012/02/10/wcf-rest-output-caching.html
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Time : ITime
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
