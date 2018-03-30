using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCF.REST.Hosting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITime" in both code and config file together.
    [ServiceContract(Namespace = "http://www.digitcyber.com/")]
    public interface ITime
    {
        [WebGet(UriTemplate = "/current", ResponseFormat = WebMessageFormat.Json)]
        [AspNetCacheProfile("default")]
        DateTime GetCurrentTime();
    }
}
