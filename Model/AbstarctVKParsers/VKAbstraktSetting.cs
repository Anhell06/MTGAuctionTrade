using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionerMTG.Model.AbstarctVKParsers
{
    class VKAbstraktSetting : IParserSettings
    {
        public VKAbstraktSetting(int start, int end, string owner_id)
        {
            StartPoint = start;
            EndPoint = end;
            userToken = File.ReadAllLines("UserInf.txt");
            Postfix = String.Concat("access_token=", userToken[0], "&owner_id=", owner_id, "&v=5.52&count=");
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




    }
}
