using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStockPile
{

    public void AddPiece(TileManager.TypeMetal typeMetal, int ammount);
    public void RemovePiece(TileManager.TypeMetal typeMetal, int ammount);
    public int CanTransact(TileManager.TypeMetal typeMetal, int amount);
    public Dictionary<TileManager.TypeMetal, int> RemoveLastPieces(int amount);
    public GameObject GetInstance();
    public int GetAvailableStorage();




}


