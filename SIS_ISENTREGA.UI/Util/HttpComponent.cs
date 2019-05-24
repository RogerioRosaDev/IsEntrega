using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace SIS_ISENTREGA.UI.Util
{
    public class HttpComponent
    {
        public static T Post<T>(string url, object data,string token)
        {
            return Request<T>(url, data, "application/json", "POST", null, token);
        }
        public static T Post<T>(string url, object data, string contentType, string method, string token)
        {
            return Request<T>(url, data, contentType, method, null, token);
        }
        public static T Post<T>(string url, object data, int timeout, string token)
        {
            return Request<T>(url, data, "application/json", "POST", timeout, token);
        }
        public static T Post<T>(string url, object data, string contentType, string method, int timeout, string token)
        {
            return Request<T>(url, data, contentType, method, timeout, token);
        }

        public static T Put<T>(string url, object data, string method, int? timeoutn, string token)
        {
            return Request<T>(url, data, "application/json", method, timeoutn, token);
        }
        private static T Request<T>(string url, object data, string contentType, string method, int? timeout,string token)
        {

            JavaScriptSerializer jss = new JavaScriptSerializer();
            //serializa o objeto
            var json = jss.Serialize(data);
            //converte o objeto em byte
            var dataSend = Encoding.UTF8.GetBytes(json);
            //declara o retorno
            var retono = string.Empty;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = method;
            req.Headers.Add(HttpRequestHeader.Authorization, string.Format("bearer {0} ", token));
            req.ContentType = contentType;
            req.ContentLength = dataSend.Length;
            req.Timeout = 999999;
            if (timeout.HasValue)
                req.Timeout = timeout.Value;

            //Adiciona o objeto que será enviado na requisição.
            using (var stream = req.GetRequestStream())
                stream.Write(dataSend, 0, dataSend.Length);

            try
            {
                //Faz a chamada e recupera a resposta.
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    retono = streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {

                throw;
            }

            return jss.Deserialize<T>(retono.ToString());
        }
    }
}