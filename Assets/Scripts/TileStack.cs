using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStack : MonoBehaviour
{
    private static List<TileManager> stackOTiles = new List<TileManager>();

    private void OnEnable()
    {
        SimpleGameEvents.OnTileDestroyed += sequenceOnTilesDeath;
        SimpleGameEvents.OnStartGameplay += disableColliders;
    }
    private void OnDisable()
    {
        SimpleGameEvents.OnTileDestroyed -= sequenceOnTilesDeath;
        SimpleGameEvents.OnStartGameplay -= disableColliders;
    }
    private void sequenceOnTilesDeath(TileManager tile)
    {
        removeTile(tile);
        checkIfEmpty();
        enableLastTilesCollider();
    }

    private void removeTile(TileManager tile)
    {
        stackOTiles.Remove(tile);
    }

    private void checkIfEmpty()
    {
        if (stackOTiles.Count == 0)
        {
            SimpleGameEvents.OnLevelComplete?.Invoke();
        }
    }

    private void enableLastTilesCollider()
    {
        if (stackOTiles.Count - 1 > -1) {
            stackOTiles[stackOTiles.Count - 1].GetComponent<BoxCollider>().enabled = true; 
        }
            
        
    }
    private void disableColliders()
    {
        foreach (var item in stackOTiles)
        {
            item.GetComponent<BoxCollider>().enabled = false;
        }
        stackOTiles[stackOTiles.Count - 1].GetComponent<BoxCollider>().enabled = true;
    }
    //---Get Set---
    public static List<TileManager> StackOTiles
    {

        get => stackOTiles;

        set
        {
            stackOTiles = value;

        }
    }



}
