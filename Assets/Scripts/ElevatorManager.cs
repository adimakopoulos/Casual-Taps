using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour , IStockPile
{
    StockPile myStockPile;

    public Action <int>OnDeposit;
    public Action OnWithDraw;
    private void Awake()
    {
        myStockPile = new StockPile(0,0,0,100);
    }


    public void AddPiece(TileManager.TypeMetal typeMetal, int ammount) {
        var isAbleToStore = myStockPile.Deposit(typeMetal, ammount);
        Debug.Log("isAbleToStore= " + isAbleToStore + " //myStockPile.Total="+ myStockPile.getCurentTotal());
        if (isAbleToStore)
        {
            OnDeposit?.Invoke(ammount);
        }


    }
    public void RemovePiece()
    {        
        var a = myStockPile.withdraw(TileManager.TypeMetal.coal , 10);
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
