using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockPileManager : MonoBehaviour , IStockPile
{
    StockPile myStockPileData;

    public Action <int>OnDeposit;
    public Action OnWithDraw;
    private void Awake()
    {
        myStockPileData = new StockPile(0,0,0,100);
    }


    public void AddPiece(TileManager.TypeMetal typeMetal, int ammount) {
        var isAbleToStore = myStockPileData.Deposit(typeMetal, ammount);
        //Debug.Log("isAbleToStore= " + isAbleToStore + " //myStockPile.Total="+ myStockPileData.getCurentTotal());
        if (isAbleToStore)
        {
            OnDeposit?.Invoke(ammount);
        }


    }
    public void RemovePiece()
    {        
        var a = myStockPileData.withdraw(TileManager.TypeMetal.coal , 10);
        if (a!=0)
        {
            OnWithDraw?.Invoke();
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }


}
