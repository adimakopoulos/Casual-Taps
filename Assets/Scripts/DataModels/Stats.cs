using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats 
{
    public int score;
    public int damage;
    public int gold;
    public int gamelevel;

    public Stats(int score, int damage, int gold, int gamelevel)
    {
        this.score = score;
        this.damage = damage;
        this.gold = gold;
        this.gamelevel = gamelevel;
    }
    public Stats()
    {
        score = 0;
        damage = 10;
        gold = 0;
        gamelevel = 1;
    }
}
