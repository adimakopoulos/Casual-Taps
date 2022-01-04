using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterManager : MonoBehaviour
{
    [SerializeField]
    public Stats myStats;
    private void Awake()
    {
        loadLastPlayedLevel();
          
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    private void loadLastPlayedLevel() {
        myStats = JsonManager.Load();
    }
    private void ResetStats()
    {
        JsonManager.Save(new Stats());
    }
}
