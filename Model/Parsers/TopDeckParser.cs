using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AuctionerMTG.Model.AuctionJObject;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace AuctionerMTG.Model.Parsers
{
    class TopDeckParser : IParser
    {

        public List<IAuction> Parse(IHtmlDocument document, DataType dataType)
        {
            List<string> list = new List<string>();
            IEnumerable<IElement> items = document.QuerySelectorAll("script");

            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }

            List<TopDeckJObject> trades = JsonToList(ConvertTopDeckTextToJson(list.Last()), "parser");

            List<IAuction> l = new List<IAuction>();
            
            foreach (var trade in trades)
            {
                l.Add(trade);
            }
            
            return l;
        }

        private string ConvertTopDeckTextToJson(string TextGetFromHTML)
        {
            TextGetFromHTML = TextGetFromHTML.Substring(TextGetFromHTML.LastIndexOf(@"JSON.parse(") + 18);
            TextGetFromHTML = TextGetFromHTML.Substring(0, TextGetFromHTML.LastIndexOf(@"),") - 7);
            TextGetFromHTML = TextGetFromHTML.Replace(@"\\", @"\");
            TextGetFromHTML = Regex.Replace(TextGetFromHTML, @"\\u([0-9A-Fa-f]{4})", m => "" + (char)Convert.ToInt32(m.Groups[1].Value, 16));
            TextGetFromHTML = @"{""parser"":[" + TextGetFromHTML + @"]}";


            return TextGetFromHTML;
        }

        private List<TopDeckJObject> JsonToList(string JSON, string JToken)
        {
            JObject jObject = JObject.Parse(JSON);
            JToken list = jObject[JToken];
            List<TopDeckJObject> trades = list.ToObject<List<TopDeckJObject>>();
            trades.Reverse();
            return trades;
        }
    }
}
