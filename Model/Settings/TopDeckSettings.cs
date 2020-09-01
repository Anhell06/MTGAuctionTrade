using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionerMTG.Model.ParsersSettings
{
    class TopDeckSettings : IParserSettings
    {
        public TopDeckSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }

        public string BaseURL { get; set; } = "https://topdeck.ru";
        public string Postfix { get; set; } = "/apps/toptrade/auctions#p=";
        public int StartPoint { get; set; } = 1;
        public int EndPoint { get; set; } = 1;
                
    }

}
