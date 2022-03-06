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

}
