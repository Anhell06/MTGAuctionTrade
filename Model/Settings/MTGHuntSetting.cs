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
        public int StartPoint { get; set; } = 100;
        public int EndPoint { get; set; } = 100;

        

    }

}
