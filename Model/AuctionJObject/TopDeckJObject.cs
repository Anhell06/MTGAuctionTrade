using AngleSharp;
using AuctionerMTG;
using System.Collections.Generic;


namespace AuctionerMTG.Model.AuctionJObject
{
    public class Seller
    {

        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string refs { get; set; }
    }

    public class TopDeckJObject : IAuction
    {

        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string date_estimated { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lot { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string image { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string start_bid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string current_bid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bid_amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string shipping_info_quick { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string shipping_info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int bin_value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string date_published { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Seller seller { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string date_estimated_conv { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string image_path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string date_published_conv { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string time_left { get; set; }


        public string Price
        {
            get
            {
                return start_bid + " / " + current_bid;
            }
        }

        public string Name => lot;

        public string Time => time_left;

        public string url => "https://topdeck.ru/apps/toptrade/auctions/" + id;

        public override string ToString()
        {
            return lot;
        }
    }

    public class Root
    {

        /// <summary>
        /// 
        /// </summary>
        public List<TopDeckJObject> parser { get; set; }
    }

}