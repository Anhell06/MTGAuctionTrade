
using AuctionerMTG;
using AuctionerMTG.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
namespace AuctionJObject
{
    public class Photo
    {
        public int album_id { get; set; }
        public int date { get; set; }
        public int id { get; set; }
        public int owner_id { get; set; }
        public bool has_tags { get; set; }
        public string access_key { get; set; }
        public int height { get; set; }
        public string photo_130 { get; set; }
        public string photo_604 { get; set; }
        public string photo_75 { get; set; }
        public int post_id { get; set; }
        public string text { get; set; }
        public int user_id { get; set; }
        public int width { get; set; }
        public string photo_1280 { get; set; }
        public string photo_2560 { get; set; }
        public string photo_807 { get; set; }
    }
    public class Attachment
    {
        public string type { get; set; }
        public Photo photo { get; set; }
    }

    public class Comments
    {
        public int count { get; set; }
    }

    public class Likes
    {
        public int count { get; set; }
    }

    public class Reposts
    {
        public int count { get; set; }
    }

    public class MTGHuntJObject : IAuction
    {
        public int id { get; set; }
        public int from_id { get; set; }
        public int owner_id { get; set; }
        public int date { get; set; }
        public int marked_as_ads { get; set; }
        public string post_type { get; set; }
        public string text { get; set; }
        public int is_pinned { get; set; }
        public List<Attachment> attachments { get; set; }
        public Comments comments { get; set; }
        public Likes likes { get; set; }
        public Reposts reposts { get; set; }

        public string Name
        {
            get
            {
                return GetParamFeomText(text, @"Описание лота: ", "\nСостояние лота:");
            }
        }

        public string Time
        {
            get
            {
                return GetParamFeomText(text, @"Дата и время окончания: ", @"(МСК)");
            }
        }

        private string GetParamFeomText(string text, string startText, string lastText)
        {
            try
            {
                text = text.Substring(text.IndexOf(startText) + startText.Length);
                text = text.Substring(0, text.LastIndexOf(lastText));
                return text;
            }
            catch (System.ArgumentOutOfRangeException)
            {

                return " Аукцион завершен или не существует";
            }

        }
        private string ConvertTopDeckTextToJson(string JSON)
        {
            JSON = GetParamFeomText(JSON, "items", "}}");
            JSON = @"{""items" + JSON + @"}";
            return JSON;
        }

        private List<Comment> JsonToList(string JSON, string JToken)
        {
            try
            {
                Thread.Sleep(300);
                JObject jObject = JObject.Parse(JSON);
                JToken list = jObject[JToken];
                List<Comment> trades = list.ToObject<List<Comment>>();
                trades.Reverse();
                return trades;
            }
            catch (Newtonsoft.Json.JsonReaderException)
            {
                List<Comment> trades = new List<Comment>();
                Comment c = new Comment();
                c.text = "Error 322";
                trades.Add(c);
                return trades;
            }
            
        }

        public string Price
        {
            get
            {

                string price;
                string owner_id = "-177193845";
                string[] access_token = File.ReadAllLines("UserInf.txt");
                string startPrice;
                price = GetParamFeomText(text, @"Стартовая цена:", "\nМинимальный шаг:");
                startPrice = price;

                if (comments.count == 0)
                {
                    return string.Concat(startPrice, @" / 0");
                }
                string url = string.Concat("https://api.vk.com/method/wall.getComments?access_token=", access_token[0], "&owner_id=", owner_id,
                    "&v=5.52&count=1&sort=desc&post_id=", id);
                WebClient wc = new WebClient();
                string answer = wc.DownloadString(url);
                List<Comment> trades = JsonToList(ConvertTopDeckTextToJson(answer), "items");
                price = trades[0].ToString();
                byte[] s = Encoding.Default.GetBytes(price);
                price = Encoding.UTF8.GetString(s);
                price = GetParamFeomText(price, "(", " рублей)");
                return string.Concat(startPrice, " / ",price);
            }
        }

        public string url
        {
            get
            {
                return string.Concat(@"https://vk.com/mtg_hunt?w=wall-177193845_", id);
            }
        }
    }

    public class Response
    {
        public int count { get; set; }
        public List<MTGHuntJObject> items { get; set; }
    }

    public class Roots
    {
        public List<Response> response { get; set; }
    }
}
