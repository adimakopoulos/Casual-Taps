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

    const string path = "Materials/TypesOfTiles/";
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
    /// <summary>
    /// first letter must be Capital.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Material GetMaterialByName(string name) {
        name = char.ToUpper(name[0])+ name.Substring(1);


        var MatirialName = "Mat" + name;
        if (name.Contains("Coal")) {
            return Resources.Load<Material>(path+ MatirialName);
        }
        if (name.Contains("Gold"))
        {
            return Resources.Load<Material>(path + MatirialName);
        }
        if (name.Contains("Iron"))
        {
            return Resources.Load<Material>(path + MatirialName);
        }
        return null; 

    }
    public static TileManager.TypeMetal GetTypeByMaterial(Material Mat)
    {
        if (Mat.name.Contains("Coal"))
        {
            return TileManager.TypeMetal.coal;
        }
        if (Mat.name.Contains("Gold"))
        {
            return TileManager.TypeMetal.gold;
        }
        if (Mat.name.Contains("Iron"))
        {
            return TileManager.TypeMetal.iron;
        }
        return TileManager.TypeMetal.NoMateial;

    }
}
