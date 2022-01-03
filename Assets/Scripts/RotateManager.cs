using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.AddRelativeTorque(new Vector3(0,0,300));
        rb.angularDrag = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
