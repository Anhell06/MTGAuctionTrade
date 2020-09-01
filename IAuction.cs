using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionerMTG
{
    interface IAuction
    {
        string Name { get; }
        string Time { get; }
        string Price { get; }
        string url { get; }

    }
}
