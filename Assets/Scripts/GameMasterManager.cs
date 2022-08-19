using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMasterManager : MonoBehaviour
{
    /// <summary>
    /// Data are loaded in after Awake Function has Run.
    /// Use MonoBehaviour Start to get the correct data.
    /// </summary>
    public static GameMasterManager GMMInstance;
    public Stats myStats;
    public Shop myShop;//TODO: Shop should be its own class.
    public List <People> myPeopleGroups= new List<People>();
    /// <summary>
    /// This Variable is only for testing. 
    /// It is used to increace the health(How much damage the player need to do) of the tiles. 
    /// </summary>
    public readonly int  DifficultyModifier=1;
    public bool LoadUI;


    private void Awake()
    {
        loadLastPlayedLevelData();
        setSingleton();
        loadSceneUI();
        QualitySettings.vSyncCount = 0;
        //SceneManager.LoadSceneAsync(0);

    }



    private void OnEnable()
    {
        SimpleGameEvents.OnLevelComplete += IncreaceLevel;
        SimpleGameEvents.OnTileDestroyed += increaseOre;
        SimpleGameEvents.OnLevelComplete += SaveProgress;
        SimpleGameEvents.OnLevelComplete += SetNextLevel;
        SimpleGameEvents.OnShowShopUI += loadShopScene;
        SimpleGameEvents.OnHideShopUI += unloadShopScene;
    }

    private void OnDisable()
    {
        SimpleGameEvents.OnTileDestroyed -= increaseOre;
        SimpleGameEvents.OnLevelComplete -= IncreaceLevel;
        SimpleGameEvents.OnLevelComplete -= SaveProgress;
        SimpleGameEvents.OnLevelComplete -= SetNextLevel;
        SimpleGameEvents.OnShowShopUI -= loadShopScene;
        SimpleGameEvents.OnHideShopUI -= unloadShopScene;
    }
    private void SaveProgress() {
        JsonManager.Save(myStats);
        JsonManager.Save(GameObject.Find("Shop").GetComponent<ShopManager>().getShopData());
        JsonManager.Save(myPeopleGroups);
    }
    private void increaseOre(TileManager tile) {
        myStats.IronOre += tile.MetalPieces;
        SimpleGameEvents.OnUI_TXT_Change?.Invoke();
    }

    /// <summary>
    /// Load all game related stats like Level number and amount of player Damage
    /// that are localy stored at Application.persistentDataPath
    /// </summary>
    private void loadLastPlayedLevelData() {

        if (JsonManager.Load() != null && JsonManager.LoadShop() != null )
        {
            myStats = JsonManager.Load();
            myShop = JsonManager.LoadShop();
            myPeopleGroups = JsonManager.LoadGroupOfPeople();
        }
        else
        {
            myStats = new Stats();
            myShop = new Shop();
            var scrComponents =  GameObject.FindObjectsOfType<PeopleManager>();
            for (int i = 0; i < scrComponents.Length; i++)
            {
                Debug.Log(i);
                myPeopleGroups.Add( new People(scrComponents[i].gameObject.name));
            }
        }
    }

    //TODO: implement. Only for testing.
    private void ResetStats()
    {
        //JsonManager.Reset( Filename);
    }
    private void IncreaceLevel() {
        myStats.Gamelevel++;
        myStats.TileHealth += DifficultyModifier*1;
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

    public SpawnManager spawner;
    private void SetNextLevel()
    {
        if (spawner == null) {
            Debug.LogError("Set Spawn Manager!");
            return;
        }
        spawner.enabled = true;
        spawner.InitialNumberOfTileToSpawn = 10;
    }

    private void loadSceneUI()
    {
        var scene = SceneManager.GetSceneByName("UI");
        if (!(scene.IsValid()))
        {
            SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
        }
    }

    private void loadShopScene() {
        var scene = SceneManager.GetSceneByName("UI_SHOP");
        if (!(scene.IsValid())) {
           SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive); 
        }
        
    }

    private void unloadShopScene() {
        var scene = SceneManager.GetSceneByName("UI_SHOP");
        if (scene.IsValid())
            SceneManager.UnloadSceneAsync("UI_SHOP");
    }


}
