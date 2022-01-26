using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    const int RateCommon = 70;
    const int RateRare = 25;
    const int RateLegendary = 5;
    public  enum  Rarity { Common, Rare, Legendary};
    //public static Stats operator ++(Stats gameRoomData) { return gameRoomData; }
    public static Rarity GetRandomRarity()
    {

        var rand = Random.Range(0, 101);


        if (rand <= RateCommon)
        {
            return Rarity.Common;
        }
        else {
            rand -= RateCommon;
        }


        if (rand <= RateRare)
        {
            return Rarity.Rare;
        }
        else
        {
            rand -= RateRare;
        }


        if (rand <= RateLegendary)
        {
            return Rarity.Legendary;
        }
        else
        {
            Debug.Log("Something went wrong");
            return 0;
        }


    }
}
