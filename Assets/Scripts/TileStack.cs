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
        try
        {
            removeTile(tile);
            checkIfEmpty();
        }
        catch (Exception e) { 
            throw new Exception("sequenceOnTilesDeath {0}", e );
        }
    }

    private void removeTile(TileManager tile)
    {
        Debug.Log("Num of Tiles in Stack was: " + stackOTiles.Count);
        stackOTiles.Remove(tile);
        Debug.Log("tile Removed: "+tile.gameObject.name);
        Debug.Log("Num of Tiles in Stack is: " + stackOTiles.Count);

    }

    private void checkIfEmpty()
    {
        Debug.Log("checkIfEmpty: is Stack Empty?");
        if (stackOTiles.Count == 0)
        {
            SimpleGameEvents.OnLevelComplete?.Invoke();
            Debug.Log("Stack was Empty " + stackOTiles.Count);
        }
        else {
            enableLastTilesCollider();
            Debug.Log("its not empty");

        }
    }

    private void enableLastTilesCollider()
    {
        if (stackOTiles.Count != 0) {
            stackOTiles[stackOTiles.Count - 1].GetComponent<BoxCollider>().enabled = true;
            Debug.Log("enable Last Tiles Collider " + stackOTiles[stackOTiles.Count - 1].gameObject.name);
        }
            
        
    }
    private void disableColliders()
    {
        foreach (var item in stackOTiles)
        {
            item.GetComponent<BoxCollider>().enabled = false;
        }

        if (stackOTiles.Count != 0) 
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
