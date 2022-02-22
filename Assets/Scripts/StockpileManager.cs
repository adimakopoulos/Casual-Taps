using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockPileManager : MonoBehaviour, IStockPile
{
    [SerializeField]
    public StockPile myStockPileData;
    private int currentlyStored;
    public Action <int,TileManager.TypeMetal>OnDeposit;
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
            OnDeposit?.Invoke(amount,typeMetal);
        }


    }
    public void RemovePiece(TileManager.TypeMetal typeMetal, int amount)
    {        
        
        var canTransactWith = myStockPileData.CanTransact(typeMetal, amount);
        if (canTransactWith > 0 && myPlacementManager.cashedGO.Count >= canTransactWith)
        {
            
            OnWithDraw?.Invoke(myStockPileData.Withdraw(typeMetal, amount));
        }



    }
    public int CanTransact(TileManager.TypeMetal typeMetal, int amount)
    {
        return myStockPileData.CanTransact(typeMetal, amount);
    }
    public Dictionary<TileManager.TypeMetal, int> RemoveLastPieces(int amount)
    {

        
        if ( myPlacementManager.cashedGO.Count >0&& myPlacementManager.cashedGO.Count >= amount)
        {
            var Dic = new Dictionary<TileManager.TypeMetal, int>();
            Dic.Add(TileManager.TypeMetal.coal, 0);
            Dic.Add(TileManager.TypeMetal.iron, 0);
            Dic.Add(TileManager.TypeMetal.gold, 0);
            for (int i = 0; i < amount; i++)
            {
                if (myPlacementManager.cashedGO[0].GetComponent<MeshRenderer>().material.name.Contains("Coal")) { 
                    OnWithDraw?.Invoke(myStockPileData.Withdraw(TileManager.TypeMetal.coal, 1));
                    Dic[TileManager.TypeMetal.coal] += 1;
                    continue;
                }
                if (myPlacementManager.cashedGO[0].GetComponent<MeshRenderer>().material.name.Contains("Iron")) { 
                    OnWithDraw?.Invoke(myStockPileData.Withdraw(TileManager.TypeMetal.iron, 1));
                    Dic[TileManager.TypeMetal.iron]+=1;
                    continue;
                }
                if (myPlacementManager.cashedGO[0].GetComponent<MeshRenderer>().material.name.Contains("Gold")) { 
                    OnWithDraw?.Invoke(myStockPileData.Withdraw(TileManager.TypeMetal.gold, 1));
                    Dic[TileManager.TypeMetal.gold]+=1;
                }
            }
            return Dic;



        }
            return null;


    }

    public GameObject GetInstance() {
        return gameObject;
    }
    public int GetAvailableStorage() {
        return myStockPileData.Capacity-myStockPileData.getCurentTotal();
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
