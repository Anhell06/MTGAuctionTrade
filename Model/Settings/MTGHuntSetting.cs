using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Cache;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using xNet;

namespace AuctionerMTG.Model.ParsersSettings
{
    class MTGHuntSetting : IParserSettings
    {
        public MTGHuntSetting(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
            userToken = File.ReadAllLines ("UserInf.txt");
            Postfix = String.Concat("access_token=", userToken[0], "&owner_id=-177193845&v=5.52&count=");
            Params.Add(ListAuctionParam.NameEnd, "\nСостояние лота:");
            Params.Add(ListAuctionParam.NameStart, "Описание лота: ");
            Params.Add(ListAuctionParam.PriceEnd, "(");
            Params.Add(ListAuctionParam.PriceStart, "рублей)");
            Params.Add(ListAuctionParam.StartPriceEnd, "Стартовая цена: ");
            Params.Add(ListAuctionParam.StartPriceStart, "\nМинимальный шаг:");
            Params.Add(ListAuctionParam.TimeEnd, "Дата и время окончания: ");
            Params.Add(ListAuctionParam.TimeStart, "(МСК)");
        }
        private string[] userToken;
        private string postfix;

        public string BaseURL { get; set; } = "http://api.vk.com/method/wall.get?";
        public string Postfix
        {
            get
            {
                return postfix;
            }
            set
            {
                postfix = value;
            }
        }
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }

        public Dictionary<ListAuctionParam, string> Params;

        

    }

}
