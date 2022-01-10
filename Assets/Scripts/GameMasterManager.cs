using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterManager : MonoBehaviour
{
    public static GameMasterManager GMMInstance;
    public Stats myStats;
    public Shop myShop;//TODO: Shop should be its own entity.
   
    /// <summary>
    /// This Variable is only for testing. 
    /// It is used to increace the health(How much damage the player need to do) of the tiles. 
    /// </summary>
    public readonly int  DifficultyModifier=1;

    private void Awake()
    {
        loadLastPlayedLevel();
        setSingleton();


    }

    private void OnEnable()
    {
        SimpleGameEvents.OnLevelComplete += IncreaceLevel;
        SimpleGameEvents.OnTileDestroy += increaseOre;
        SimpleGameEvents.OnLevelComplete += SaveProgress;
    }

    private void OnDisable()
    {
        SimpleGameEvents.OnTileDestroy -= increaseOre;
        SimpleGameEvents.OnLevelComplete -= IncreaceLevel;
        SimpleGameEvents.OnLevelComplete -= SaveProgress;

    }
    private void SaveProgress() {
        JsonManager.Save(myStats);
        JsonManager.Save(myShop);
    }
    private void increaseOre(TileManager tile) {
        myStats.IronOre += tile.IronOrePieces;
        SimpleGameEvents.OnUI_TXT_Change?.Invoke();
    }

    /// <summary>
    /// Load all game related stats like Level number and amount of player Damage
    /// that are localy stored at Application.persistentDataPath
    /// </summary>
    private void loadLastPlayedLevel() {

        if (JsonManager.Load() != null && JsonManager.LoadShop() != null)
        {
            myStats = JsonManager.Load();
            myShop = JsonManager.LoadShop();
        }
        else
        {
            myStats = new Stats();
            myShop = new Shop();
        }
    }

    //TODO: implement. Only for testing.
    private void ResetStats()
    {
        //JsonManager.Reset( Filename);
    }
    private void IncreaceLevel() {
        myStats.Gamelevel++;
        myStats.TileHealth += DifficultyModifier*2;
    }
    /// <summary>
    /// set instance of this script to be public and accessed by everyone using this instance
    /// </summary>
    private void setSingleton()
    {
        if (GMMInstance == null)
        {
            GMMInstance = this;
        }
    }

}
