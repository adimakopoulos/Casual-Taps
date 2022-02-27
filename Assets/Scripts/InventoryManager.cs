using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IStockPile
{
    /// <summary>
    /// Returns the GoldOre, CoalOre, IronOre values
    /// </summary>
    public static Action<int, int, int> OnInvetoryChange;
    public static Action OnSmallPiecesProcessed;
    public static Action OnDepositFailed;
    public RainFallEffect[] Spawners;//Is set in the inspector

    StockPile _myStockPileData;
    private void Awake()
    {

        _myStockPileData = new StockPile(0, 0, 0, 1000);


    }



    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }

    private void Update()
    {


    }



    public void Add1SmallPiece(TileManager.TypeMetal typeMetal)
    {
        if (typeMetal == TileManager.TypeMetal.coal)
        {

            if (_myStockPileData.Deposit(TileManager.TypeMetal.coal, 1))
            {
                Spawners[0].Add1SmallPiece();
            }
            else
            {
                OnDepositFailed?.Invoke();
            }

        }
        if (typeMetal == TileManager.TypeMetal.gold)
        {
            if (_myStockPileData.Deposit(TileManager.TypeMetal.gold, 1))
            {
                Spawners[1].Add1SmallPiece();
            }
            else
            {
                OnDepositFailed?.Invoke();
            }


        }
        if (typeMetal == TileManager.TypeMetal.iron)
        {
            if (_myStockPileData.Deposit(TileManager.TypeMetal.iron, 1))
            {
                Spawners[2].Add1SmallPiece();
            }
            else
            {
                OnDepositFailed?.Invoke();
            }

        }
        OnSmallPiecesProcessed?.Invoke();

        OnInvetoryChange?.Invoke(_myStockPileData.CoalOre, _myStockPileData.GoldOre, _myStockPileData.IronOre);
    }

    public void RemovePiece(TileManager.TypeMetal typeMetal, int ammount)
    {
        for (int i = 0; i < ammount; i++)
        {
            if (typeMetal == TileManager.TypeMetal.coal)
            {


                if (_myStockPileData.Withdraw(TileManager.TypeMetal.coal, 1) > 0)
                {
                    Spawners[0].RemoveFirstStoredGameObject();
                }
            }
            if (typeMetal == TileManager.TypeMetal.gold)
            {

                if (_myStockPileData.Withdraw(TileManager.TypeMetal.gold, 1) > 0)
                {
                    Spawners[1].RemoveFirstStoredGameObject();
                }


            }
            if (typeMetal == TileManager.TypeMetal.iron)
            {
                if (_myStockPileData.Withdraw(TileManager.TypeMetal.iron, 1) > 0)
                {
                    Spawners[2].RemoveFirstStoredGameObject();
                }
            }

        }
        OnInvetoryChange?.Invoke(_myStockPileData.CoalOre, _myStockPileData.GoldOre, _myStockPileData.IronOre);

    }

    public int CanTransact(TileManager.TypeMetal typeMetal, int amount)
    {
        return _myStockPileData.CanTransact(typeMetal, amount);
    }

    public Dictionary<TileManager.TypeMetal, int> RemoveLastPieces(int amount)
    {
        throw new NotImplementedException();
    }

    public GameObject GetInstance()
    {
        return this.gameObject;
    }

    public int GetAvailableStorage()
    {
        return _myStockPileData.Capacity - _myStockPileData.getCurentTotal();
    }
}
