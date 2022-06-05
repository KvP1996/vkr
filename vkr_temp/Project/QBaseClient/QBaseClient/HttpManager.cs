using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace QBaseClient
{
    class HttpManager
    {
        const string baseUrl = "http://localhost:36246/";
        public static string Get(string url)
        {
            return GetDelete(url, "GET");
        }
        public static string Post(string url, string content)
        {
            return PostPut(url, content, "POST");
        }
        public static string Put(string url, string content)
        {
            return PostPut(url, content, "PUT");
        }
        public static string Delete(string url)
        {
            return GetDelete(url, "DELETE");
        }
        static string PostPut(string url, string content, string method)
        {
            var request = WebRequest.Create(baseUrl + url);
            request.Method = method;
            request.Timeout = Int32.MaxValue;
            byte[] byteArray = Encoding.UTF8.GetBytes("=" + Uri.EscapeDataString(content));
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            ServicePointManager.DefaultConnectionLimit = Int32.MaxValue;

            //WebResponse response;
            //try
            //{
            //    response = request.GetResponse();
            //}
            //catch { response = null; }

            //if (response != null)
            //{
            //    dataStream = response.GetResponseStream();            
            //}
            //var sr = new StreamReader(dataStream);
            //return sr.ReadToEnd();
            //return "*";
            //2
            string responseString = String.Empty;
            using (var response = request.GetResponse())
            {
                using (Stream objStream = response.GetResponseStream())
                {
                    using (StreamReader objReader = new StreamReader(objStream))
                    {
                        responseString = objReader.ReadToEnd();
                        objReader.Close();
                    }
                    objStream.Flush();
                    objStream.Close();
                }
                response.Close();
            }
            return responseString;
            //3
        }

        static string GetDelete(string url, string method)
        {
            var request = WebRequest.Create(baseUrl + url);
            request.Method = method;
            WebResponse response = request.GetResponse();
            var sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd();
        }
    }
}
