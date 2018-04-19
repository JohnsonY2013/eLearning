using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PostByWebClient();
            CallByWebClient();
            Console.WriteLine();

            PostByHttpClient();
            CallByHttpClient();
            Console.WriteLine();

            PostByWebRequest();
            CallByWebRequest();
            Console.WriteLine();

            Console.ReadLine();
        }

        static string serviceUrl = "http://localhost:64669/Employees.svc";
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
            using (var reader = new StreamReader(webClient.OpenRead(serviceUrl + "/all")))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
        static void PostByWebClient()
        {
            object input = new
            {
                Id = "010",
                Name = "Loly",
                Department = "Admin",
                Grade = "30"
            };

            string inputJson = JsonConvert.SerializeObject(input);
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            var reponse = client.UploadString(serviceUrl + "/create", inputJson);
            Console.WriteLine();
        }


        /// <summary>
        /// https://blogs.msdn.microsoft.com/dsnotes/2017/09/19/wcf-consume-wcf-rest-service-by-httpclient/
        /// </summary>
        static void CallByHttpClient()
        {
            string response = null;

            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var uri = new Uri(serviceUrl + "/all");

                response = client.GetStringAsync(uri).Result;
                Console.WriteLine(response);
                //var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response);

                //foreach(var item in obj)
                //{
                //    Console.WriteLine(item.ToString());
                //}
            }
        }

        static void PostByHttpClient()
        {
            object input = new
            {
                Id = "011",
                Name = "Zak",
                Department = "Sales",
                Grade = "99"
            };

            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var uri = new Uri(serviceUrl + "/create");
                var request = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                var response = client.PostAsync(uri, request).Result;

            }
        }

        static void CallByWebRequest()
        {
            var webRequest = WebRequest.Create(serviceUrl + "/all");
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

        static void PostByWebRequest()
        {
            var webRequest = WebRequest.Create(serviceUrl + "/create");
            webRequest.Method = "POST";
            webRequest.ContentType = @"application/json; charset=utf-8";

            object input = new
            {
                Id = "012",
                Name = "Aden",
                Department = "Sales",
                Grade = "88"
            };

            byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(input));

            using (Stream stream = webRequest.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
            }

            using (HttpWebResponse httpResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                using (var reader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
        }
    }
}
