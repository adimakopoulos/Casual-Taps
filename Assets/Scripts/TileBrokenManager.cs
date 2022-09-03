using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TileBrokenManager : MonoBehaviour
{
    public Rigidbody[] BrokenPieces;
    private float TimeToLand = 4f;
    public Material metalMaterial;
    /// <summary>
    /// Pieces dont move Much From the Position that they land. So by waiting 4 seconds i can record an "accurate"
    /// location and Add them to Available pieces
    /// to be gathered by the workers.
    /// </summary>
    public System.Action<TileBrokenManager> On4SecondsPass;
    private void Awake()
    {

    }

    void Start()
    {
        addForce();
        setTypeOfMaterial();
        SimpleGameEvents.OnTileShutter?.Invoke(this);

    }

    private void setTypeOfMaterial()
    {
        var MeshRenderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var renderer in MeshRenderers)
        {
            renderer.material = metalMaterial;
        }
    }

    private void addForce()
    {
        gameObject.transform.position += Vector3.up * 1;//move up, to unstuck it 

        int direction = Random.Range(0, 2);
        if (direction == 0)
        {//down right side of screen
            foreach (var rb in BrokenPieces)
            {
                rb.AddForce(new Vector3(-1 * Random.Range(600f, 800f), 400f, direction * Random.Range(200f, 200f)));
                rb.AddTorque(new Vector3(Random.Range(-100f, 100f), 1, 1 * Random.Range(-100f, 100f)));
            }
        }
        else
        {//down left side of screen
            foreach (var rb in BrokenPieces)
            {
                rb.AddForce(new Vector3(-1 * Random.Range(400f, 400f), 400f, direction * Random.Range(800f, 1000f)));
                rb.AddTorque(new Vector3(Random.Range(-100f, 100f), 1, 1 * Random.Range(-100f, 100f)));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeToLand -= Time.deltaTime;
        if (TimeToLand < 0)
        {
            On4SecondsPass?.Invoke(this);
        }
    }

}
