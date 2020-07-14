using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace RestfulAPITestDemo
{
    public class RestClient
    {
        private static string BaseUri;
        public RestClient(string baseUri)
        {
            BaseUri = baseUri;
        }


        #region Delete
        private static string Delete(string uri, string data = "")
        {
            string serviceUrl = string.IsNullOrEmpty(BaseUri) ? uri : $"{BaseUri}/{uri}";
            return CommonHttpRequest(serviceUrl, "DELETE", data);
        }
        #endregion

        #region Put
        private static string Put(string uri, string data)
        {
            string serviceUrl = string.IsNullOrEmpty(BaseUri) ? uri : $"{BaseUri}/{uri}";
            return CommonHttpRequest(serviceUrl, "PUT", data);
        }
        #endregion

        #region POST
        private static string Post(string uri, string data)
        {
            string serviceUrl = string.IsNullOrEmpty(BaseUri) ? uri : $"{BaseUri}/{uri}";
            return CommonHttpRequest(serviceUrl, "Post", data);
        }
        #endregion

        #region GET
        private static string Get(string uri)
        {
            string serviceUrl = string.IsNullOrEmpty(BaseUri) ? uri : $"{BaseUri}/{uri}";
            return CommonHttpRequest(serviceUrl, "GET");
        }
        #endregion

        #region  私有方法
        private static string CommonHttpRequest(string url, string type, string data = "")
        {
            HttpWebRequest myRequest = null;
            Stream outstream = null;
            HttpWebResponse myResponse = null;
            StreamReader reader = null;
            try
            {
                //构造http请求的对象
                myRequest = (HttpWebRequest)WebRequest.Create(url);

                //设置
                myRequest.ProtocolVersion = HttpVersion.Version11;
                myRequest.Method = type;
                
                if (data.Trim() != "")
                {
                    myRequest.ContentType = @"application/json";
                    myRequest.MediaType = "application/json";
                    myRequest.Accept = "application/json";
                    myRequest.Timeout = 500000;

                    myRequest.Headers["Accept-Language"] = "zh-CN,zh;q=0.";
                    myRequest.Headers["Accept-Charset"] = "GBK,utf-8;q=0.7,*;q=0.3";

                    //转成网络流
                    byte[] buf = Encoding.GetEncoding("UTF-8").GetBytes(data);
                    myRequest.ContentLength = buf.Length;
                    outstream = myRequest.GetRequestStream();
                    outstream.Flush();
                    outstream.Write(buf, 0, buf.Length);
                    outstream.Flush();
                    outstream.Close();
                }
                // 获得接口返回值
                myResponse = (HttpWebResponse)myRequest.GetResponse();
                reader = new StreamReader(myResponse.GetResponseStream() 
                                          ?? throw new InvalidOperationException(), Encoding.UTF8);
                string ReturnXml = reader.ReadToEnd();
                reader.Close();
                myResponse.Close();
                myRequest.Abort();
                return ReturnXml;
            }
            catch (WebException wex)
            {
                outstream?.Close();
                reader?.Close();
                myResponse?.Close();
                myRequest?.Abort();
                string pageContent = new StreamReader(wex.Response.GetResponseStream() 
                                                      ?? throw new InvalidOperationException()).ReadToEnd();
                return "错误：" + pageContent;
            }
        }
        #endregion

        #region 通用请求
        /// <summary>
        /// Http通用请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="type"></param>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static string HttpRequest(string url, HttpType type, string inputData = "")
        {
            switch (type)
            {
                case HttpType.PUT:
                    return Put(url, inputData);
                case HttpType.GET:
                    return Get(url);
                case HttpType.POST:
                    return Post(url, inputData);
                case HttpType.DELETE:
                    return Delete(url, inputData);
            }
            return "";
        }


        /// <summary>
        /// Http通用请求
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="uri"></param>
        /// <param name="type"></param>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static string HttpRequest(string ip, string port, string uri, HttpType type, string inputData = "")
        {
            string url = "https://" + ip + ":" + port + uri;
            return HttpRequest(url, type, inputData);
        }


        #endregion


        public enum HttpType
        {
            PUT = 0,
            GET = 1,
            POST = 2,
            DELETE = 3
        }
    }
}
