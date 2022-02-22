using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateManager : MonoBehaviour
{

    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {


    }

    private void OnEnable()
    {
        SimpleGameEvents.OnPickAxeRelease += doRotation;
    }
    private void OnDisable()
    {
        SimpleGameEvents.OnPickAxeRelease -= doRotation;
    }
    /// <summary>
    /// Does a small physics based rotation when the pick axe is released
    /// </summary>
    private void doRotation() {

        rb.AddRelativeTorque(new Vector3(0, 0, 300));
        rb.angularDrag = 0.5f;
    }


}
