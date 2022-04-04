using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnManager : MonoBehaviour
{
    //TODO: THE Prefab GAMEOBJECTS SHOULD BE CALLED BY A POOL SYSTEM TO MINIMIZE GARBAGE COLLECTION
    public GameObject Prefab;
    public int SpawnNum;
    public float TimeInterval;
    readonly float _delay = 2;
    float _timePassed;
    float _timeUntilDisabled = -5f;

    private List<GameObject> _spawnedGO = new List<GameObject>();
    private void Awake()
    {
        //gameObject.AddComponent<DebugStuff.DebugStuff>();
        if (Prefab == null)
        {
            Debug.Log("Prefab Instance not set!");
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

    private void doRainEffect()
    {

        _timePassed -= Time.deltaTime;
        if (_timePassed <= 0f && SpawnNum != 0)
        {
            _timePassed = TimeInterval;
            var go = Instantiate(Prefab, this.transform);
            go.name += SpawnNum.ToString();
            
            _spawnedGO.Add(go);
            SpawnNum--;
        }

    }
    private void disablePhysics()
    {
        if (_timePassed < _timeUntilDisabled)
        {

            //TODO: Looping while useing GetComponent seems really slow. Need Better Implemetation
            foreach (var item in _spawnedGO)
            {
                item.GetComponent<Rigidbody>().isKinematic = true;
                TileStack.StackOTiles.Add(item.GetComponent<TileManager>());
            }
            SimpleGameEvents.OnStartGameplay?.Invoke();


            _spawnedGO.Clear();
            _spawnedGO = new List<GameObject>();
            this.enabled = false;
        }
    }
}
