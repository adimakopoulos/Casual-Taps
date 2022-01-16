using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    //TODO: migrate shop here
    private void Awake()
    {
        Shop _shopstats = GameMasterManager.GMMInstance.myShop;
    }

}
