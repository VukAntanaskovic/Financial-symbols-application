using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace FEtest.API
{
    public class APIHelper
    {
        private static readonly string baseURL = "https://webservice.gvsi.com/query/";
        private IApiCallback apiCallback;

        private bool hasInternet()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }

        public APIHelper(IApiCallback apiCallback)
        {
            this.apiCallback = apiCallback;
        }
        
        public  async void GetAll(string value)
        {
            apiCallback.showLoading();

            if (!hasInternet())
            {
                apiCallback.hideLoading();
                apiCallback.onErrorResult("Molimo Vas proverite internet konekciju.");
            }


            HttpClient client = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes("desktopapp:ThePa55word");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            HttpResponseMessage res = await client.GetAsync(baseURL + "json/GetDaily/tradedatetimegmt/open/high/low/close/volume?pricesymbol=\"" + value + "\"&daysBack=100");
            HttpContent content = res.Content;

            string data = await content.ReadAsStringAsync();

            apiCallback.hideLoading();

            if(data != null)
            {
                apiCallback.onGetResult(data);
            }

            else
            {
                apiCallback.onErrorResult("Trazeni simbol ne postoji.");
            }
        }

    }
}
