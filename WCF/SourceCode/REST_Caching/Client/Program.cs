using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Web;

namespace WCF.REST.Client
{
    class Program
    {
        public static object JsonConvert { get; private set; }

        static void Main(string[] args)
        {
            CallByWebClient();
            CallByWebRequest();
            CallByHttpClient();
            CallByFactoryChannel();

            Console.ReadLine();
        }

        /// <summary>
        /// CANNOT WORK
        /// 不能工作
        /// http://blogs.msdn.com/b/carlosfigueira/archive/2012/03/26/mixing-add-service-reference-and-wcf-web-http-a-k-a-rest-endpoint-does-not-work.aspx
        /// </summary>
        static void CallByRef()
        {
            try
            {
                var serviceUrl = "http://localhost:64669/Time.svc";

                using (var factory = new WebChannelFactory<TimeServices.ITime>(new Uri(serviceUrl)))
                {
                    var proxy = factory.CreateChannel();
                    var result = proxy.GetCurrentTime();

                    Console.WriteLine(result);
                }
            }
            catch { }
        }

        static void CallByFactoryChannel()
        {
            using (var client = new WebChannelFactory<ITime>("TimeClient"))
            {
                var proxy = client.CreateChannel();
                var result = proxy.GetCurrentTime();
                Console.WriteLine(result);
            }
        }

        static void CallByWebClient()
        {
            // Test for
            // <webHttp automaticFormatSelectionEnabled="true"/>
            var webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "application/json");
            webClient.Headers.Add("Accept", "application/json");
            //webClient.Headers["Content-type"] = "application/json";
            //webClient.Headers["Accept"] = "application/json";
            //webClient.Encoding = Encoding.UTF8;
            using (var reader = new StreamReader(webClient.OpenRead("http://localhost:64669/Time.svc/current")))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }

        /// <summary>
        /// https://blogs.msdn.microsoft.com/dsnotes/2017/09/19/wcf-consume-wcf-rest-service-by-httpclient/
        /// </summary>
        static void CallByHttpClient()
        {
            string response = null;

            using (var client = new HttpClient())
            {
                var uri = new Uri("http://localhost:64669/Time.svc/current");
                response = client.GetStringAsync(uri).Result;

                //var jsonRequest = JsonConvert.SerializeObject("123");
                //var stringContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                //response = await client.PostAsync(uri, stringContent);
            }

            Console.WriteLine(response);
        }

        static void CallByWebRequest()
        {
            var serviceUri = "http://localhost:64669/Time.svc";

            var webRequest = WebRequest.Create($"{serviceUri}\\current");
            webRequest.Method = "GET";
            webRequest.ContentType = @"application/json; charset=utf-8";

            using (var webResponse = webRequest.GetResponse() as HttpWebResponse)
            {
                //var enc = System.Text.Encoding.GetEncoding("utf-8");
                using (var reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
        }

    }
}
