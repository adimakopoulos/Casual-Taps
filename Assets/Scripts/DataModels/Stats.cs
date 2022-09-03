using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats 
{
    public int Score;
    public int Damage;
    public int Coins;
    public int IronOre,CoalOre,GoldOre;
    public int Gamelevel;
    public int TileHealth;
    public int AmmountOfTilesPerLevel;


    public Stats()
    {
        Score = 0;
        Damage = 1;
        Coins = 0;
        IronOre = 0;
        CoalOre = 0;
        GoldOre = 0;
        Gamelevel = 1;
        TileHealth = 1;
        AmmountOfTilesPerLevel = 8;
    }

    public Stats(int score, int damage, int coins, int ironOre, int coalOre, int goldOre, int gamelevel, int tileHealth, int ammountOfTilesPerLevel)
    {
        Score = score;
        Damage = damage;
        Coins = coins;
        IronOre = ironOre;
        CoalOre = coalOre;
        GoldOre = goldOre;
        Gamelevel = gamelevel;
        TileHealth = tileHealth;
        AmmountOfTilesPerLevel = ammountOfTilesPerLevel;
    }
}
