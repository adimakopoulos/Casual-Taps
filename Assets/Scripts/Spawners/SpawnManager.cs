using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnManager : MonoBehaviour
{
    //TODO: THE Prefab GAMEOBJECTS SHOULD BE CALLED BY A POOL SYSTEM TO MINIMIZE GARBAGE COLLECTION
    public GameObject Prefab;
    public int InitialNumberOfTileToSpawn;
    public float TimeInterval;
    readonly float _delay = 2;
    float _timePassed;
    float _timeUntilDisabled = -5f;

    private List<GameObject> _spawnedTilesGO = new List<GameObject>();
    private void Awake()
    {
        if (Prefab == null)
        {
            Debug.Log("Prefab Instance not set!");
        }
        if (InitialNumberOfTileToSpawn <= 0)
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

    private void doRainEffect()
    {

        _timePassed -= Time.deltaTime;
        if (_timePassed <= 0f && InitialNumberOfTileToSpawn != 0)
        {
            _timePassed = TimeInterval;
            var go = Instantiate(Prefab, this.transform);
            go.name += InitialNumberOfTileToSpawn.ToString();
            
            _spawnedTilesGO.Add(go);
            InitialNumberOfTileToSpawn--;
        }

    }
    private void disablePhysics()
    {
        if (_timePassed < _timeUntilDisabled)
        {

            //TODO: Looping while useing GetComponent seems really slow. Need Better Implemetation
            foreach (var item in _spawnedTilesGO)
            {
                item.GetComponent<Rigidbody>().isKinematic = true;
                TileStack.StackOTiles.Add(item.GetComponent<TileManager>());
            }
            SimpleGameEvents.OnStartGameplay?.Invoke();


            _spawnedTilesGO.Clear();
            _spawnedTilesGO = new List<GameObject>();
            this.enabled = false;
        }
    }
}
