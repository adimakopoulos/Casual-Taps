using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats 
{
    public int Score;
    public int Damage;
    public int Gold;
    public int IronOre;
    public int Gamelevel;
    public int TileHealth;

    public Stats(int score, int damage, int gold, int ironOre, int gamelevel, int tileHealth)
    {
        Score = score;
        Damage = damage;
        Gold = gold;
        IronOre = ironOre;
        Gamelevel = gamelevel;
        TileHealth = tileHealth;
    }

    public Stats()
    {
        Score = 0;
        Damage = 1;
        Gold = 0;
        IronOre = 0;
        Gamelevel = 1;
        TileHealth = 1;
    }


}
