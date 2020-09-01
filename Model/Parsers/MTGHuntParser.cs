using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AuctionJObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace AuctionerMTG.Model.Parsers
{
    class MTGHuntParser : IParser
    {

        public List<IAuction> Parse(IHtmlDocument document, DataType dataType)
        {
            List<string> list = new List<string>();

            IEnumerable<IElement> items = document.QuerySelectorAll("body");

            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }

            List<MTGHuntJObject> trades = JsonToList(ConvertTopDeckTextToJson(list.Last<string>()), "items");//ConvertTopDeckTextToJson(list.Last()), "response");

            List<IAuction> l = new List<IAuction>();

            foreach (var trade in trades)
            {
                l.Add(trade);
            }
            l.Reverse();
            return l;
        }

        private string ConvertTopDeckTextToJson(string JSON)
        {
            JSON = JSON.Substring(27);
            JSON = JSON.Substring(0, JSON.Length - 2);
            JSON = @"{" + JSON + @"}";
            return JSON;
        }

        private List<MTGHuntJObject> JsonToList(string JSON, string JToken)
        {
            JObject jObject = JObject.Parse(JSON);
            JToken list = jObject[JToken];
            List<MTGHuntJObject> trades = list.ToObject<List<MTGHuntJObject>>();
            trades.Reverse();
            return trades;
        }
    }
}
