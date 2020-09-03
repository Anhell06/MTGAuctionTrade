using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AuctionerMTG.Model.AuctionJObject
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

    public class VKAbstractJObject : IAuction
    {
        public VKAbstractJObject(Dictionary<ListAuctionParam, string> value)
        {
            Params = value;
        }
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

        private string price;

        private string[] access_token = File.ReadAllLines("UserInf.txt");

        private string startPrice;

        public Dictionary<ListAuctionParam, string> Params { get; set; }

        public string Name
        {
            get
            {
                string name = Substring.GetSubstringNoIncluded(text, Params[ListAuctionParam.NameStart], Params[ListAuctionParam.NameEnd]);
                return name.Replace("\n", " ");
            }
        }

        public string Time
        {
            get
            {
                return Substring.GetSubstringNoIncluded(text, Params[ListAuctionParam.TimeStart], Params[ListAuctionParam.TimeEnd]);
            }
        }

        public string Price
        {
            get
            {
                return GetPrice();
            }
        }

        private string GetPrice()
        {

            startPrice = Substring.GetSubstringNoIncluded(text, Params[ListAuctionParam.StartPriceStart], Params[ListAuctionParam.StartPriceEnd]);

            if (this.comments.count == 0)
            {
                return string.Concat(startPrice, @" / 0");
            }

            string GetCommentURL = string.Concat
                (
                "https://api.vk.com/method/wall.getComments?access_token=", access_token[0],
                "&owner_id=", owner_id,
                "&v=5.52&count=1&sort=desc&post_id=", id
                );

            List<Comment> comments = new List<Comment>();

            using (WebClient wc = new WebClient())
            {
                string JsonComment = wc.DownloadString(GetCommentURL);
                JsonComment = @"{" + Substring.GetSubstringIncluded(JsonComment, @"""items", "}}") + @"}";
                Thread.Sleep(300);
                comments = Converter<Comment>.JsonToList(JsonComment, "items");
            }

            price = comments[0].ToString();
            price = Encoding.UTF8.GetString(Encoding.Default.GetBytes(price)); // Black Magic
            price = Substring.GetSubstringIncluded(price, Params[ListAuctionParam.PriceStart], Params[ListAuctionParam.PriceEnd]);
            return string.Concat(startPrice, " / ", price);
        }

        public string url
        {
            get
            {
                return string.Concat(@"https://vk.com/mtg_hunt?w=wall", owner_id, "_", id);
            }
        }
    }

    public class Response
    {
        public int count { get; set; }
        public List<VKAbstractJObject> items { get; set; }
    }

    public class Roots
    {
        public List<Response> response { get; set; }
    }
}

