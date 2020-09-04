using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AuctionerMTG.Controler
{
    class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;

        /// <summary>
        /// В данном класе собираеться адресная строка из префикса и постфикса
        /// </summary>
        /// <param name="settings"></param>
        public HtmlLoader(Model.IParserSettings settings)
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "C# App");
            url = $"{settings.BaseURL}{settings.Postfix}CurentID";
        }
        /// <summary>
        /// Возвращает код страницы с заданным id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> GetSourseByPage(int id)
        {
            string currentUrl = url.Replace("CurentID", id.ToString());
            HttpResponseMessage responce = await client.GetAsync(currentUrl);
            string source = null; //need default

            if (responce!= null && responce.StatusCode == HttpStatusCode.OK)
            {
                source = await responce.Content.ReadAsStringAsync();
            }
            return source;
        }
    }
}
