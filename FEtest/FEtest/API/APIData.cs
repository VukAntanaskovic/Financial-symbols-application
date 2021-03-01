using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEtest.API
{
    public class APIData
    {
        public APIData(string tradedatetimegmt, string open, string high, string low, string close, string volume, string sMA)
        {
            this.tradedatetimegmt = tradedatetimegmt;
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
            this.volume = volume;
            Pokretni_Prosek = sMA;
        }

        public string tradedatetimegmt { get; set; }

        public string open { get; set; }
        public string high { get; set; }

        public string low { get; set; }

        public string close { get; set; }

        public string volume { get; set; }

        public string Pokretni_Prosek { get; set; }
    }
}
