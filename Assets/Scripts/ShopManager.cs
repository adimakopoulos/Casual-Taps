using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    Shop _shopstats;
    public int SellPrice;
    //TODO: migrate shop here
    private void Start()
    {
        _shopstats = GameMasterManager.GMMInstance.myShop;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Open Shop UI!");
        SimpleGameEvents.OnhideShopUI?.Invoke();
    }

    public Shop getShopData() { 
    return _shopstats;  
    }

}
