using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AuctionerMTG.Controler;
using AuctionerMTG.Model.AuctionJObject;
using AuctionJObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace AuctionerMTG.Model.Parsers
{
    class VKAbstractParser : IParser
    {
        private AuctionNameList NameVkGroop;

        public VKAbstractParser(AuctionNameList value)
        {
            NameVkGroop = value;
        }

        public List<IAuction> Parse(IHtmlDocument document, DataType dataType)
        {
            List<string> list = new List<string>();

            IEnumerable<IElement> items = document.QuerySelectorAll("body");

            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }
            List<VKAbstractJObject> trades = Converter<VKAbstractJObject>.JsonToList(ConvertTopDeckTextToJson(list.Last<string>()), "items");
            
            List<IAuction> l = new List<IAuction>();

            foreach (var trade in trades)
            {
                trade.Params = BDVKTextParams.GetAuctionParams(NameVkGroop);

                if (trade.Name != "")
                {
                    GetComent(trade);
                    l.Add(trade);
                }
            }
            l.Reverse();
            return l;
        }

        /// <summary>
        /// Собирает в читаемый, прграммой, вид строку
        /// </summary>
        /// <param name="JSON">JSON строка</param>
        /// <returns></returns>
        private string ConvertTopDeckTextToJson(string JSON)
        {
            JSON = Substring.GetSubstringStartIncluded(JSON, @"""items", "}}");
            JSON = @"{" + JSON + @"}";
            return JSON;
        }

        /// <summary>
        /// Получает и устанавливает коментарии к посту
        /// </summary>
        /// <param name="abstractJObject">Пост на стене</param>
        private void GetComent(VKAbstractJObject abstractJObject)
        {
            if (abstractJObject.comments.count != 0)
            {

                string GetCommentURL = string.Concat
                    (
                    "https://api.vk.com/method/wall.getComments?access_token=", (File.ReadAllLines("UserInf.txt"))[0],
                    "&owner_id=", abstractJObject.owner_id,
                    "&v=5.52&count=1&sort=desc&post_id=", abstractJObject.id
                    );

                List<Comment> comments = new List<Comment>();

                using (WebClient wc = new WebClient())
                {
                    string JsonComment = wc.DownloadString(GetCommentURL);
                    JsonComment = @"{" + Substring.GetSubstringStartIncluded(JsonComment, @"""items", "}}") + @"}";
                    Thread.Sleep(300);
                    if (abstractJObject.id == 127605)
                    {

                    }
                    comments = Converter<Comment>.JsonToList(JsonComment, "items");
                }
                byte[] price = Encoding.Default.GetBytes(comments[0].ToString());
                string coment = Encoding.UTF8.GetString(price);
                abstractJObject.comment = coment; // Black Magic

            }
        }

    }
}
