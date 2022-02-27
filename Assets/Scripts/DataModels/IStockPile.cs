using System.Collections.Generic;
using UnityEngine;

public interface IStockPile
{

    public void Add1SmallPiece(TileManager.TypeMetal typeMetal);
    public void RemovePiece(TileManager.TypeMetal typeMetal, int ammount);
    public int CanTransact(TileManager.TypeMetal typeMetal, int amount);
    public Dictionary<TileManager.TypeMetal, int> RemoveLastPieces(int amount);
    public GameObject GetInstance();
    public int GetAvailableStorage();




}


