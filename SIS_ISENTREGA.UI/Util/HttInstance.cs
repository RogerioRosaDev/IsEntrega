using System.Net.Http;

namespace SIS_ISENTREGA.UI.Util
{
    public class HttInstance
    {
        private static HttpClient httpClientInstance;
        private HttInstance()
        {

        }
        public static HttpClient GetHttpClientInstance()
        {
            if (httpClientInstance == null)
            {
                httpClientInstance = new HttpClient();
                httpClientInstance.DefaultRequestHeaders.ConnectionClose = false;
            }
            return httpClientInstance;
        }
    }
}