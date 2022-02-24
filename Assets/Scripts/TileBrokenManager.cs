using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TileBrokenManager : MonoBehaviour
{
    public Rigidbody[] BrokenPieces ;
    private float TimeToLand = 4f;
    public Material metalMaterial;
    /// <summary>
    /// Pieces dont move Much From the Position that they land. So by waiting 4 seconds i can record an "accurate"
    /// location and Add them to Available pieces
    /// to be gathered by the workers.
    /// </summary>
    public System.Action <TileBrokenManager> On4SecondsPass;
    private void Awake()
    {
        SimpleGameEvents.OnTileShutter?.Invoke(this);

    }

    void Start()
    {
        foreach (var rb in BrokenPieces)
        {
            rb.AddForce(new Vector3(-1 * Random.Range(0.5f, 1f), 1, 1 * Random.Range(0.5f, 1f)) * 600);
            rb.AddTorque(new Vector3(Random.Range(-100f, 100f), 1, 1 * Random.Range(-100f, 100f)) );
        }

        var MeshRenderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var renderer in MeshRenderers)
        {
            renderer.material = metalMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeToLand -= Time.deltaTime;
        if (TimeToLand < 0) {
            On4SecondsPass?.Invoke(this);
        }
    }
    
}
