using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStack : MonoBehaviour
{
    private static List<TileManager> stackOTiles =new List<TileManager>();

    private void OnEnable()
    {
        SimpleGameEvents.OnTileDestroyed += removeTile;
        SimpleGameEvents.OnTileDestroyed += checkIfEmpty;
    }
    private void OnDisable()
    {
        SimpleGameEvents.OnTileDestroyed -= removeTile;
        SimpleGameEvents.OnTileDestroyed -= checkIfEmpty;
    }

    private void removeTile(TileManager tile) {
        if (tile.Health <= 0)
        stackOTiles.Remove(tile);
       
    }

    private void checkIfEmpty(TileManager tile)
    {
        if (stackOTiles.Count == 0) {
            SimpleGameEvents.OnLevelComplete?.Invoke();
        }
    }

    //---Get Set---
    public static List<TileManager> StackOTiles { 
        
        get => stackOTiles;

        set { stackOTiles = value;
            
        }
    }



}
