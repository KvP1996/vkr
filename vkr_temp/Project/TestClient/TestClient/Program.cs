using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using TestClient.QService;
using System.Web;
using System.Net.Http;
using System.Net.Http.Formatting;


namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //string result = PostRequest("http://localhost:36246/algorithms/3", "qweqweqweqwe");
            string result = DeleteRequest("http://localhost:36246/algorithms/3");
            //string result = PutRequest("http://localhost:36246/determinants/2", "{\"name\":\"updexmpl3\",\"description\":\"updexmpl3\"}");
            //string result = GetRequest("http://localhost:36246/algorithms/");
            Console.WriteLine(result);
            Console.ReadKey();
        }

        static string PostRequest(string url, string content)
        {
            var request = WebRequest.Create(url);
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes("=" + content);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            var sr = new StreamReader(dataStream);
            return sr.ReadToEnd();
        }

        static string DeleteRequest(string url)
        {
            var request = WebRequest.Create(url);
            request.Method = "DELETE";
            WebResponse response = request.GetResponse();
            var sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd();
        }

        static string PutRequest(string url, string content)
        {
            var request = WebRequest.Create(url);
            request.Method = "PUT";
            byte[] byteArray = Encoding.UTF8.GetBytes("=" + content);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            var sr = new StreamReader(dataStream);
            return sr.ReadToEnd();
        }

        static string GetRequest(string url)
        {
            var request = WebRequest.Create(url);
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            var sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd();
        }
    }
}
