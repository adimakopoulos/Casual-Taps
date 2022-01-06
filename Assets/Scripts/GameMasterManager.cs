using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterManager : MonoBehaviour
{
    public static GameMasterManager GMMInstance;
    public Stats myStats;

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



    // Update is called once per frame
    void Update()
    {
        


    }
    private void OnEnable()
    {
        SimpleGameEvents.OnLevelComplete += IncreaceLevel;
    }

    private void OnDisable()
    {
        SimpleGameEvents.OnLevelComplete -= IncreaceLevel;
        JsonManager.Save(myStats);
    }

    /// <summary>
    /// Load all game related stats like Level number and amount of player Damage
    /// that are localy stored at Application.persistentDataPath
    /// </summary>
    private void loadLastPlayedLevel() {
        myStats = JsonManager.Load();
    }

    //for testing
    private void ResetStats()
    {
        JsonManager.Save(new Stats());
    }
    private void IncreaceLevel() {
        myStats.Gamelevel++;
        myStats.TileHealth += DifficultyModifier;
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
