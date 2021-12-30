using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TileBrokenManager : MonoBehaviour
{
    public Rigidbody[] BrokenPieces ;
    public float TimeToLive;
    void Start()
    {
        foreach (var rb in BrokenPieces)
        {
            rb.AddForce(new Vector3(-1 * Random.Range(0f, 1f), 1, 1 * Random.Range(0f, 1f)) * 300);
            rb.AddTorque(new Vector3(-1 * Random.Range(0f, 1f), 1, 1 * Random.Range(0f, 1f)) , ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
