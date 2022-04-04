using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shop
{
    public int BuyDamagePrice;
    public int ShopLevel;
    public int UpgradeBonusDmg;
    public int SellPriceIron, SellPriceGold, SellPriceCoal;
    public int SellPriceSlaveGroupA, SellPriceSlaveGroupB, SellPriceSlaveGroupC;
    //private Dictionary<string, string> openWith = new Dictionary<string, string>();

    public Shop()
    {
        BuyDamagePrice = 5;
        ShopLevel = 1;
        UpgradeBonusDmg = 1;
        SellPriceIron = 10;
        SellPriceGold = 10;
        SellPriceCoal = 10;
    }

    public void incrementUpgradeCost() {
        this.BuyDamagePrice += 10;
    }

    public bool SellGold(int amount)
    {
        GameMasterManager.GMMInstance.myStats.GoldOre -= amount;
        if (GameMasterManager.GMMInstance.myStats.GoldOre >= amount)
        {
            GameMasterManager.GMMInstance.myStats.Coins += amount * SellPriceGold;
            GameMasterManager.GMMInstance.myStats.GoldOre -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool SellIron(int amount)
    {
        GameMasterManager.GMMInstance.myStats.IronOre -= amount;
        if (GameMasterManager.GMMInstance.myStats.IronOre >= amount)
        {
            GameMasterManager.GMMInstance.myStats.Coins += amount * SellPriceIron;
            GameMasterManager.GMMInstance.myStats.IronOre -= amount;
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool SellCoal(int amount)
    {
        GameMasterManager.GMMInstance.myStats.CoalOre -= amount;
        if (GameMasterManager.GMMInstance.myStats.CoalOre >= amount)
        {
            GameMasterManager.GMMInstance.myStats.Coins += amount * SellPriceCoal;
            GameMasterManager.GMMInstance.myStats.CoalOre -= amount;
            return true;
        }
        else
        {
            return false;
        }

    }



}
