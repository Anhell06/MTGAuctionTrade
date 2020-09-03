using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionerMTG.Model
{
    static class Converter<T> where T : class
    {
        /// <summary>
        /// Конвертирует строку формата JSON в список определенного класса, в случае ошибке возвращает null 
        /// </summary>
        /// <param name="JSON">Текст</param>
        /// <param name="JToken">Идентификатор формата {"JToken":[{},{}]}</param>
        /// <returns></returns>
        public static List<T> JsonToList(string JSON, string JToken)
        {
            try
            {
                JObject jObject = JObject.Parse(JSON);
                JToken list = jObject[JToken];
                List<T> trades = list.ToObject<List<T>>();
                trades.Reverse();
                return trades;
            }
            catch (Newtonsoft.Json.JsonReaderException)
            {
                return null;
            }

        }
    }
    

}
