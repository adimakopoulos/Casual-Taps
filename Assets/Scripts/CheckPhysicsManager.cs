using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPhysicsManager : MonoBehaviour
{
    public Collider[] hitColliders;
    public LayerMask m_LayerMask;
    public int DetectedTiles=0;
    private Vector3 almost0Velocity = new Vector3(0.01f,0.01f,0.01f);
    // Start is called before the first frame update
    void Start()

    {
        DetectedTiles=GameObject.Find("TileSpawner").GetComponent<SpawnManager>().InitialNumberOfTileToSpawn;
    }
    private void OnDisable()
    {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);
        DetectedTiles = hitColliders.Length;
        if (DetectedTiles > 0)
        {
            foreach (var target in hitColliders)
            {
                if(target.name.Contains("TileBroken")&& target.GetComponent<Rigidbody>().velocity.x > almost0Velocity.x)
                    target.GetComponent<Rigidbody>().AddForce(new Vector3(-100, 400, 100));
            }
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
