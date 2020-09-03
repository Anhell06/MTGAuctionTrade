using System;
using System.Collections.Generic;

public static class BDVKTextParams
{
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
    Dictionary<ParamTextSubsring, string> MTGHunt;

	public BDVKTextParams()
	{
        SetMTGHunt();

    }

    private void SetMTGHunt()
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
}
