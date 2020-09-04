using AuctionerMTG.Model;
using AuctionerMTG.Model.AbstarctVKParsers;
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
                    VkDefaultSetting(AuctionNameList.MTGHunt, "-177193845");
                    break;
                case AuctionNameList.Mtg_auction:
                    VkDefaultSetting(AuctionNameList.Mtg_auction, "-173659094");
                    break;
                case AuctionNameList.Black_Lotus:
                    VkDefaultSetting(AuctionNameList.Black_Lotus, "-185486377");
                    break;
                case AuctionNameList.Hobbycards:
                    VkDefaultSetting(AuctionNameList.Hobbycards, "-148678889");
                    break;
                case AuctionNameList.MTG_KKU:
                    VkDefaultSetting(AuctionNameList.MTG_KKU, "-179014245");
                    break;
                default:
                    new NullReferenceException("Неверные настройки");
                    break;
            }
        }

        private static void VkDefaultSetting(AuctionNameList name , string owner_id)
        {
            parser = new ParserWorker(new VKAbstractParser(name));
            parser.Settings = new VKAbstraktSetting(70, 71, owner_id);
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

                    parser = new ParserWorker(new VKAbstractParser(AuctionNameList.MTGHunt));
                    parser.Settings = new VKAbstraktSetting(startPage, endPage, "-177193845");
                    break;
                case AuctionNameList.Mtg_auction:
                    parser = new ParserWorker(new VKAbstractParser(AuctionNameList.Mtg_auction));
                    parser.Settings = new VKAbstraktSetting(startPage, endPage, "-173659094");
                    break;
                default:
                    new NullReferenceException("Неверные настройки");
                    break;
            }
        }



    }
}
