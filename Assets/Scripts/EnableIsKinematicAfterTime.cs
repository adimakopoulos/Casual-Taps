using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableIsKinematicAfterTime : MonoBehaviour
{
    public System.Action<GameObject> OnSuccefullyStored;
    public float timeUntilEnabled=2f;
    float _passedSeconds=0f;
    Rigidbody _myRigidbody;

    private void Awake()
    {
        
        _myRigidbody =GetComponent<Rigidbody>();
    }
    void Update()
    {

        if (_passedSeconds > timeUntilEnabled) {
            _myRigidbody.isKinematic = false;//TODO: is set to false for testing, remember to change it back
            
            OnSuccefullyStored?.Invoke(gameObject);
            this.enabled = false;

        }
        _passedSeconds+= Time.deltaTime;
    }
}
