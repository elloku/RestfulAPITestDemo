using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace RestfulAPITestDemo
{
    public static class HttpWebRequestHelper
    {
        public static string Get()
        {
            string result = null;
            // Create the web request
            if (WebRequest.Create("http://127.0.0.1:31001/mcrp-prod-chanpinzx/api/ChanPin") is HttpWebRequest request)
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream
                    if (response != null)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());

                        // Console application output
                        result = reader.ReadToEnd();
                    }
                }
            return result;
        }


        public static string Post()
        {
            string result = null;
            Uri address = new Uri("http://127.0.0.1:31001/mcrp-prod-chanpinzx/api/ChanPin");

            // Create the web request
            if (WebRequest.Create(address) is HttpWebRequest request)
            {
                request.Method = "POST";
                request.ContentType = "application/json";

                // Create the data we want to send
                ChanPinDTO chanPin = new ChanPinDTO
                {
                    Id = "739769244446625793",
                    ChanPinMc = "api调用测试",
                    WangGuanLj = "abc",
                    GitFuWuQ = null,
                    QunZuMc = "123",
                    ChanPinBS = "api调用测试",
                    GitYongHuM = null,
                    GitMiMa = null,
                    BeiZhu = null,
                    ChanPinFZR = null,
                    ChanPinFZRXM = null,
                    KaiFaFZR = null,
                    KaiFaFZRXM = null,
                    TiYanFZR = null,
                    TiYanFZRXM = null,
                    CeShiFZR = null,
                    CeShiFZRXM = null
                };

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var data = serializer.Serialize(chanPin);

                // Create a byte array of the data we want to send
                byte[] byteData = Encoding.UTF8.GetBytes(data);

                // Set the content length in the request headers
                request.ContentLength = byteData.Length;

                // Write data
                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }

                // Get response
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream
                    if (response != null)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException());

                        result = reader.ReadToEnd();
                        // Console application output
                        Console.WriteLine(reader.ReadToEnd());
                    }
                }
            }

            return result;
        }



    }
}
