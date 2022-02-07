using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockPileManager : MonoBehaviour , IStockPile
{
    [SerializeField]
    public StockPile myStockPileData;
    private int currentlyStored;
    public Action <int>OnDeposit;
    public Action <int>OnWithDraw;
    private PlacementManager myPlacementManager;
    private void Awake()
    {
        myStockPileData = new StockPile(0,0,0,100);
        myPlacementManager = GetComponent<PlacementManager>();
    }

    public void AddPiece(TileManager.TypeMetal typeMetal, int amount) {
        var isAbleToStore = myStockPileData.Deposit(typeMetal, amount);
        //Debug.Log("isAbleToStore= " + isAbleToStore + " //myStockPile.Total="+ myStockPileData.getCurentTotal());
        if (isAbleToStore)
        {
            OnDeposit?.Invoke(amount);
        }


    }
    public void RemovePiece(TileManager.TypeMetal typeMetal, int amount)
    {        
        
        var canTransactWith = myStockPileData.Withdraw(typeMetal, amount);
        if (canTransactWith > 0 && myPlacementManager.cashedGO.Count >= canTransactWith)
        {
            OnWithDraw?.Invoke(canTransactWith);
        }
        else {
            Debug.Log("Refund" + typeMetal + " " + canTransactWith);
            myStockPileData.Deposit(typeMetal, canTransactWith);
        }


    }


    //debug Attributes
    public int Capacity, CoalOre,CurrTotal;
    private void Update()
    {
        Capacity = myStockPileData.Capacity;
        CurrTotal = myStockPileData.getCurentTotal();
        CoalOre = myStockPileData.CoalOre;
        
    }

}
