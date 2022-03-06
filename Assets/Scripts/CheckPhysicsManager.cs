using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPhysicsManager : MonoBehaviour
{
    public Collider[] hitColliders;
    public LayerMask m_LayerMask;
    public int PredictedTiles=0;
    // Start is called before the first frame update
    void Start()

    {
        PredictedTiles=GameObject.Find("TileSpawner").GetComponent<SpawnManager>().SpawnNum;
        SimpleGameEvents.OnStartGameplay += DoCheck;
    }
    private void OnDisable()
    {
        SimpleGameEvents.OnStartGameplay -= DoCheck;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void DoCheck() {
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);
        if (PredictedTiles > hitColliders.Length) {
            //Debug.Log("PredictedTiles == hitColliders.Length TRUE" );
            //throw new NotImplementedException();
        }
        
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
