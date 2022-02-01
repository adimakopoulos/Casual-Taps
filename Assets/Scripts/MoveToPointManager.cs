using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPointManager : MonoBehaviour
{
    public Vector3 TargetPosition;
    public Vector3 CurrentPosition;
    public float Speed;


    // Update is called once per frame
    void Update()
    {


        lerpBetweenPotitions();
    }



    void lerpBetweenPotitions() {
        gameObject.transform.localPosition = Vector3.Slerp(CurrentPosition, TargetPosition, Time.deltaTime / Speed);
    }
}
