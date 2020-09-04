using AuctionerMTG.Controler;
using System;
using System.Collections.Generic;

public enum ParamTextSubsring
{
    StartName,
    StartTime,
    StartPrice,
    StartNowPrice,
    EndName,
    EndTime,
    EndPrice,
    EndNowPrice,
}

public static class BDVKTextParams
{

    private static Dictionary<ParamTextSubsring, string> MTGHunt { get; set; }
    private static Dictionary<ParamTextSubsring, string> mtg_auction { get; set; }
    private static Dictionary<ParamTextSubsring, string> Black_Lotus { get; set; }
    private static Dictionary<ParamTextSubsring, string> Hobbycards { get; set; }
    private static Dictionary<ParamTextSubsring, string> MTG_KKU { get; set; }


    static BDVKTextParams()
    {
        
    }

    public static Dictionary<ParamTextSubsring, string> GetAuctionParams(AuctionNameList value)
    {
        switch (value)
        {
            case AuctionNameList.TopDeck:
                new System.ArgumentNullException();
                return null;
            case AuctionNameList.MTGHunt:
                SetMTGHunt();
                return MTGHunt;
            case AuctionNameList.Mtg_auction:
                SetMtg_auction();
                return mtg_auction;
            case AuctionNameList.Black_Lotus:
                SetBlack_Lotus();
                return Black_Lotus;
            case AuctionNameList.Hobbycards:
                SetHobbycards();
                return Hobbycards;
            case AuctionNameList.MTG_KKU:
                SetMTG_KKU();
                return MTG_KKU;
            default:
                new System.ArgumentNullException();
                return null;
        }

    }

    private static void SetMTG_KKU()
    {
        MTG_KKU = new Dictionary<ParamTextSubsring, string>
        {
            [ParamTextSubsring.EndName] = "\nСрок аукциона:",
            [ParamTextSubsring.EndNowPrice] = "",
            [ParamTextSubsring.EndPrice] = "\nМинимальный шаг",
            [ParamTextSubsring.EndTime] = @"до 23:59",
            [ParamTextSubsring.StartName] = @"Описание лота: ",
            [ParamTextSubsring.StartNowPrice] = "",
            [ParamTextSubsring.StartPrice] = @"Стартовая цена:",
            [ParamTextSubsring.StartTime] = @"Срок аукциона: "
        };
    }

    private static void SetHobbycards()
    {
        Hobbycards = new Dictionary<ParamTextSubsring, string>
        {
            [ParamTextSubsring.EndName] = "\nСостояние лота:",
            [ParamTextSubsring.EndNowPrice] = "",
            [ParamTextSubsring.EndPrice] = "\nМинимальный шаг",
            [ParamTextSubsring.EndTime] = @" в 21.00 по МСК",
            [ParamTextSubsring.StartName] = @"Описание лота: ",
            [ParamTextSubsring.StartNowPrice] = "",
            [ParamTextSubsring.StartPrice] = @"Стартовая цена:",
            [ParamTextSubsring.StartTime] = @"окончания аукциона -"
        };
    }

    private static void SetMTGHunt()
    {
        MTGHunt = new Dictionary<ParamTextSubsring, string>
        {
            [ParamTextSubsring.EndName] = "\nСостояние лота:",
            [ParamTextSubsring.EndNowPrice] = " рублей)",
            [ParamTextSubsring.EndPrice] = "\nМинимальный шаг:",
            [ParamTextSubsring.EndTime] = @"(МСК)",
            [ParamTextSubsring.StartName] = @"Описание лота: ",
            [ParamTextSubsring.StartNowPrice] = "(",
            [ParamTextSubsring.StartPrice] = @"Стартовая цена:",
            [ParamTextSubsring.StartTime] = @"Дата и время окончания: "
        };
    }
    private static void SetMtg_auction()
    {
        mtg_auction = new Dictionary<ParamTextSubsring, string>
        {
            [ParamTextSubsring.EndName] = "\nСостояние лота:",
            [ParamTextSubsring.EndNowPrice] = " была принята",
            [ParamTextSubsring.EndPrice] = "\nМинимальный шаг:",
            [ParamTextSubsring.EndTime] = @" в 20",
            [ParamTextSubsring.StartName] = @"Описание лота: ",
            [ParamTextSubsring.StartNowPrice] = "ваша ставка ",
            [ParamTextSubsring.StartPrice] = @"Стартовая цена:",
            [ParamTextSubsring.StartTime] = @"Дата и время окончания: "
        };
    }
    private static void SetBlack_Lotus()
    {
        Black_Lotus = new Dictionary<ParamTextSubsring, string>
        {
            [ParamTextSubsring.EndName] = "\nСостояние лота:",
            [ParamTextSubsring.EndNowPrice] = " рублей)",
            [ParamTextSubsring.EndPrice] = "\nМинимальный шаг:",
            [ParamTextSubsring.EndTime] = @"(МСК)",
            [ParamTextSubsring.StartName] = @"Описание лота: ",
            [ParamTextSubsring.StartNowPrice] = "(",
            [ParamTextSubsring.StartPrice] = @"Стартовая цена:",
            [ParamTextSubsring.StartTime] = @"Дата и время окончания: "
        };
    }
}
