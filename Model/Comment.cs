using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionerMTG.Model
{
    public class Comment
    {
        public int id { get; set; }
        public int from_id { get; set; }
        public int date { get; set; }
        public string text { get; set; }
        public int reply_to_user { get; set; }
        public int reply_to_comment { get; set; }
        public override string ToString()
        {
            return text;
        }
    }

    public class Response
    {
        public int count { get; set; }
        public List<Comment> items { get; set; }
    }

    public class Root
    {
        public Response response { get; set; }
    }
}
