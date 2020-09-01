using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionerMTG.Model
{
    interface IParser
    {
        /// <summary>
        /// Парсер HTML документов
        /// </summary>
        /// <param name="document"></param>
        List<IAuction> Parse(IHtmlDocument document, DataType dataType);

    }
}
