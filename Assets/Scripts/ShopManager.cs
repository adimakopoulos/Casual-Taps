using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    Shop _shopstats;
    //TODO: migrate shop here
    private void Start()
    {
        _shopstats = GameMasterManager.GMMInstance.myShop;
    }

    


}
