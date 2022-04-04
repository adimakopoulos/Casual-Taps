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
    private void OnEnable()
    {
        SimpleGameEvents.OnRaycastDone += ClickedObjectCheck;
    }

    private void OnDisable()
    {
        SimpleGameEvents.OnRaycastDone -= ClickedObjectCheck;
    }
    private void ClickedObjectCheck(GameObject go) {
        if (go.gameObject.name.Contains("Shop"))
        {
            SimpleGameEvents.OnShowShopUI?.Invoke();
        }
    }

    public Shop getShopData() { 
        return _shopstats;  
    }


}
