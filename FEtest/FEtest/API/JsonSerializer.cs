using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEtest.API
{
    public class JsonSerializer
    {
        public static List<APIData> data = new List<APIData>();

        public static void Serializer(string result)
        {
            data.Clear();
            double SMA = 0;
            JObject joResponse = JObject.Parse(result);
            JObject ojObject = (JObject)joResponse["results"];
            JArray array = (JArray)ojObject["items"];
            for (int i = 0; i < array.Count; i++)
            {
                SMA = (Convert.ToDouble(array[i]["close"]) + i) / array.Count;
                data.Add(new APIData(array[i]["tradedatetimegmt"].ToString(), array[i]["open"].ToString(), array[i]["high"].ToString(), array[i]["low"].ToString(), array[i]["close"].ToString(), array[i]["volume"].ToString(), SMA.ToString()));

            }
        }
    }
}
