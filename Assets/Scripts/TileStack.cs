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
        SimpleGameEvents.OnTileDestroyed += enableLastTilesCollider;
        SimpleGameEvents.OnStartGameplay += disableColliders;
    }
    private void OnDisable()
    {
        SimpleGameEvents.OnTileDestroyed -= removeTile;
        SimpleGameEvents.OnTileDestroyed -= checkIfEmpty;
        SimpleGameEvents.OnTileDestroyed -= enableLastTilesCollider;
        SimpleGameEvents.OnStartGameplay -= disableColliders ;
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

    private void enableLastTilesCollider(TileManager tile) {
        if (stackOTiles.Count - 1 < 0)
            return;
        stackOTiles[stackOTiles.Count - 1].GetComponent<BoxCollider>().enabled = true;
    }
    private void disableColliders() {
        foreach (var item in stackOTiles)
        {
            item.GetComponent<BoxCollider>().enabled = false;
        }
        stackOTiles[stackOTiles.Count - 1].GetComponent<BoxCollider>().enabled = true;
    }
    //---Get Set---
    public static List<TileManager> StackOTiles { 
        
        get => stackOTiles;

        set { stackOTiles = value;
            
        }
    }



}
