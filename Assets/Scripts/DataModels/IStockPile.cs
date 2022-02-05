using System;
using System.Collections;
using System.Collections.Generic;


public interface IStockPile
{

    public void AddPiece(TileManager.TypeMetal typeMetal, int ammount);

    public void RemovePiece(TileManager.TypeMetal typeMetal, int ammount);


}


