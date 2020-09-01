using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionerMTG.Model
{
    interface IParserSettings
    { 
        /// <summary>
        /// url сайта
        /// </summary>
        string BaseURL { get; set; }
        /// <summary>
        /// постфик с id страницы
        /// </summary>
        string Postfix { get; set; }
        /// <summary>
        /// Стартовая позиция страницы
        /// </summary>
        int StartPoint { get; set; }
        /// <summary>
        /// Конечная позиции страницы
        /// </summary>
        int EndPoint { get; set; }
    }
}
