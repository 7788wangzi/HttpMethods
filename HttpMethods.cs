using System.IO;
using System.Net;

namespace ConsoleApp1
{
    public class HttpMethods
    {
        public static string Get(string url, string referer, CookieContainer myCookie)
        {
            string contentToReturen = null;

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "GET";
            req.CookieContainer = myCookie;
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.100 Safari/537.36";
            req.Referer = referer;

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            myCookie.Add(resp.Cookies);

            using (StreamReader reader = new StreamReader(resp.GetResponseStream(), System.Text.Encoding.Default))
            {
                contentToReturen = reader.ReadToEnd();
            }

            return contentToReturen;
        }

        public static string Post(string url, string referer, string postData, CookieContainer myCookie)
        {
            string contentToReturn = null;

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "POST";
            req.CookieContainer = myCookie;
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.100 Safari/537.36";
            req.Referer = referer;
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
            req.ContentType = "text/html";

            Stream postStream = req.GetRequestStream();
            byte[] postBytes = System.Text.Encoding.ASCII.GetBytes(postData);
            postStream.Write(postBytes, 0, postBytes.Length);
            postStream.Dispose();

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            myCookie.Add(resp.Cookies);
            using (StreamReader reader = new StreamReader(resp.GetResponseStream(), System.Text.Encoding.Default))
            {
                contentToReturn = reader.ReadToEnd();
            }

            return contentToReturn;
        }
    }
}
