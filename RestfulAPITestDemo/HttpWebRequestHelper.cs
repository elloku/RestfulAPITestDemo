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
        public static string HttpRequest(string type)
        {
            string result = null;
            string url = null;
            if (type == "Delete")
            {
                url = "http://127.0.0.1:31001/mcrp-prod-chanpinzx/api/ChanPin/739769244446625793";
            }
            if (type == "GET")
            {
                url = "http://127.0.0.1:31001/mcrp-prod-chanpinzx/api/ChanPin";
            }
            // Create the web request
            if (WebRequest.Create(url) is HttpWebRequest request)
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream
                    if (response != null)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException());

                        // Console application output
                        result = reader.ReadToEnd();
                    }
                }
            return result;
        }


        public static string Post(string inputData = "")
        {
            string result = null;
            // Create the web request
            if (WebRequest.Create("http://127.0.0.1:31001/mcrp-prod-chanpinzx/api/ChanPin") is HttpWebRequest request)
            {
                request.Method = "Post";
                request.ContentType = "application/json";

                // Create a byte array of the data we want to send
                byte[] byteData = Encoding.UTF8.GetBytes(inputData);

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


        public static string Delete()
        {
            string result = null;

            // Create the web request
            if (WebRequest.Create("http://127.0.0.1:31001/mcrp-prod-chanpinzx/api/ChanPin/739769244446625795") is HttpWebRequest request)
            {
                request.Method = "Delete";
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

        public static string Put(string inputData = "")
        {
            string result = null;

            // Create the web request
            if (WebRequest.Create("http://127.0.0.1:31001/mcrp-prod-chanpinzx/api/ChanPin/739769244446625796") is HttpWebRequest request)
            {
                request.Method = "Put";
                request.ContentType = "application/json";

                // Create a byte array of the data we want to send
                byte[] byteData = Encoding.UTF8.GetBytes(inputData);

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
