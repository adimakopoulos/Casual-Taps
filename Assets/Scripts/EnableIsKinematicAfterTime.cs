using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableIsKinematicAfterTime : MonoBehaviour
{
    public float timeUntilEnabled=4f;
    float _passedSeconds=0f;
    Rigidbody _myRigidbody;
    private void Awake()
    {
        _myRigidbody=GetComponent<Rigidbody>();
    }
    void Update()
    {

        if (_passedSeconds > timeUntilEnabled) {
            _myRigidbody.isKinematic = true;
            this.enabled = false;
        }
        _passedSeconds+= Time.deltaTime;
    }
}
