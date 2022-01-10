using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shop
{
    public int Cost;
    public int ShopLevel;
    public int UpgradeBonusDmg;
    public int sellOrePrice;

    public Shop()
    {
        Cost = 5;
        ShopLevel = 1;
        UpgradeBonusDmg = 1;
        sellOrePrice = 10;
    }

    public void incrementUpgradeCost() {
        this.Cost += 10;
    }

}
