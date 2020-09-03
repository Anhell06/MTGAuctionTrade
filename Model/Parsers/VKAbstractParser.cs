using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AuctionerMTG.Model.AuctionJObject;
using AuctionJObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AuctionerMTG.Model.Parsers
{
    class VKAbstractParser : IParser
    {

        public List<IAuction> Parse(IHtmlDocument document, DataType dataType)
        {
            List<string> list = new List<string>();

            IEnumerable<IElement> items = document.QuerySelectorAll("body");

            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }
            List<MTGHuntJObject> trades = Converter<MTGHuntJObject>.JsonToList(ConvertTopDeckTextToJson(list.Last<string>()), "items");

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
            JSON = Substring.GetSubstringStartIncluded(JSON, @"""items", "}}");
            JSON = @"{" + JSON + @"}";
            return JSON;
        }

       
    }
}
