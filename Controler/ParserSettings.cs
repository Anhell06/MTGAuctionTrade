using AuctionerMTG.Model;
using AuctionerMTG.Model.Parsers;
using AuctionerMTG.Model.ParsersSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionerMTG.Controler
{
    static class ParserSettings
    {
        public static ParserWorker GetCurrentParser => parser;
        private static ParserWorker parser = null;

        public static void SetParser(AuctionNameList name)
        {
            switch (name)
            {
                case AuctionNameList.TopDeck:
                    parser = new ParserWorker(new TopDeckParser());
                    parser.Settings = new TopDeckSettings(0, 1);
                    break;
                case AuctionNameList.MTGHunt:
                    parser = new ParserWorker(new MTGHuntParser());
                    parser.Settings = new MTGHuntSetting(50, 51);
                    break;
                default:
                    new NullReferenceException("Неверные настройки");
                    break;
            }
        }
        public static void SetParser(AuctionNameList name, int startPage, int endPage)
        {
            switch (name)
            {
                case AuctionNameList.TopDeck:
                    parser = new ParserWorker(new TopDeckParser());
                    parser.Settings = new TopDeckSettings(startPage, endPage);
                    break;
                case AuctionNameList.MTGHunt:

                    parser = new ParserWorker(new MTGHuntParser());
                    parser.Settings = new MTGHuntSetting(startPage, endPage);
                    break;
                default:
                    new NullReferenceException("Неверные настройки");
                    break;
            }
        }



    }
}
