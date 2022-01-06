using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public static class SimpleGameEvents 
{
    //public static Action <List<GameObject>>OnFinishedBuildingColumns;
    /// <summary>
    /// When player should gain control.
    /// </summary>
    public static Action OnStartGameplay;
    /// <summary>
    /// When Tiles are 0.
    /// </summary>
    public static Action OnLevelComplete;
    /// <summary>
    /// 
    /// </summary>
    public static Action OnLevelReset;
    /// <summary>
    /// when player "Releases" the pick axe to Mine a tile.
    /// </summary>
    public static Action OnPickAxeRelease;
    /// <summary>
    /// when a tile prefab is destroyed.
    /// </summary>
    public static Action <TileManager>OnTileDestroy;

}
