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
            rb.AddForce(new Vector3(-1 * Random.Range(0.5f, 1f), 1, 1 * Random.Range(0.5f, 1f)) * 600);
            rb.AddTorque(new Vector3(Random.Range(-100f, 100f), 1, 1 * Random.Range(-100f, 100f)) );
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeToLive -= Time.deltaTime;
        if (TimeToLive < 0) {
            Destroy(this.gameObject);
        }
    }
    
}
