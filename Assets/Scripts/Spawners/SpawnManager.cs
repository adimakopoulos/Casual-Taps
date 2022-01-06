using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnManager : MonoBehaviour
{
    //TODO: THE Prefab GAMEOBJECTS SHOULD BE CALLED BY A POOL SYSTEM TO MINIMIZE GARBAGE COLLECTION
    public GameObject Prefab;
    public int SpawnNum;
    public bool DisableBoxCollider = true;
    public float TimeInterval;
    readonly float _delay = 2;
    float _timePassed;
    float _timeUntilDisabled = -5f; 

    private List<GameObject> _spawnedGO = new List<GameObject>();
    private void Awake()
    {
        
        if (Prefab == null) {
            Debug.Log("ColumnExtension Instance not set!");
        }
        if (SpawnNum <= 0)
        {
            Debug.Log("SpawnNum is 0 or less!");
        }
    }
    void Start()
    {
        _timePassed = TimeInterval + _delay;
    }

    // Update is called once per frame
    void Update()
    {
        doRainEffect();
        disablePhysics();

    }

    private void doRainEffect() {

        _timePassed -= Time.deltaTime;
        if (_timePassed <= 0f && SpawnNum != 0)
        {
            _timePassed = TimeInterval;
            _spawnedGO.Add( Instantiate(Prefab, this.transform));
            SpawnNum--;
        }

    }
    private void disablePhysics() {
        if (_timePassed < _timeUntilDisabled)
        {
            foreach (var item in _spawnedGO)
            {
                if (DisableBoxCollider)
                    item.GetComponent<BoxCollider>().enabled = false;
                item.GetComponent<Rigidbody>().isKinematic = true;
            }
            if (Prefab.name == "Tile") {
                //TODO: Looping while useing GetComponent seems really slow. Need Better Implemetation
                foreach (var item in _spawnedGO)
                {
                    TileStack.StackOTiles.Add(item.GetComponent<TileManager>());
                }
                SimpleGameEvents.OnStartGameplay?.Invoke();
                
            }
            
            
            this.enabled = false;
        }
    }
}
