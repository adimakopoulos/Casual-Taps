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
    /// when player "Releases" the pickaxe to Mine a tile.
    /// </summary>
    public static Action OnPickAxeRelease;
    /// <summary>
    /// when a tile prefab is destroyed. Returns the tile manager that is going to be destroyed.
    /// </summary>
    public static Action<TileManager> OnTileDestroyed;
    /// <summary>
    /// When the pickAxe Collides with something;
    /// </summary>
    public static Action <TileManager> OnPickAxeImpact;
    public static Action OnUI_TXT_Change;

    public static Action OnLookLeft;
    public static Action OnLookRight;
    public static Action OnLookDown;
    public static Action OnLookUp;
    /// <summary>
    /// Gets Invoked When The Camera Manager has Set A new LOOKING TARGET;
    /// 
    /// </summary>
    public static Action <int>OnPlayerCurrentlyLookingAt;

    public static Action <TileBrokenManager>OnTileShutter;

    //------------UI-----------
    public static Action<GameObject> OnRaycastDone;
    public static Action OnShowShopUI;
    public static Action OnhideShopUI;
    public static Action OnShowInvetoryUI;
    public static Action OnHideInvetoryUI;


}
