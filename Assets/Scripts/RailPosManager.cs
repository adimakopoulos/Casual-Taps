using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailPosManager : MonoBehaviour
{

    public List<Transform> RailPoints;
    public Transform LookingPoint;
    private void Awake()
    {
        foreach (Transform t in RailPoints) { 
            var r = t.gameObject.GetComponent<Renderer>();
            if (r != null) {r.enabled = false;}
        }
        LookingPoint.position = RailPoints[0].position;
    }
    private void OnEnable()
    {
        KeyListenerManager.OnMousePosChanged += MoveLookedObject;
        SimpleGameEvents.OnLookDown += SetStartingData;

    }
    private void OnDisable()
    {
        KeyListenerManager.OnMousePosChanged -= MoveLookedObject;
        SimpleGameEvents.OnLookDown -= SetStartingData;

    }

    private void SetStartingData() {
        indicator = 0;
    }
    private int indicator =0;
    private enum Direction { Clockwise, Counterclockwise }
    private Direction myDirection;
    private float sensitivity = 0.051f;
    void MoveLookedObject(Vector3 mouseDelta) {
        //If the camera is looking at the Drill movement, leave.
        if (CameraLookAtManager.currLookType == CameraLookAtManager.CameraLookType.LookingAtDrill) {
            return;
        }
        var distance = mouseDelta.x;
        //Debug.Log("distance"+ distance);
        if (distance<0)
        {
            if (myDirection == Direction.Counterclockwise) {
                SetNextIndicator();
                myDirection = Direction.Clockwise;
            }

            if (LookingPoint.position == RailPoints[indicator].position) {
                SetNextIndicator();
                myDirection = Direction.Clockwise;
            }
            LookingPoint.position = Vector3.MoveTowards(LookingPoint.position, RailPoints[indicator].position,Mathf.Abs( distance) * sensitivity);
        }
        if (distance > 0) {
            if (myDirection == Direction.Clockwise)
            {
                SetPriorIndicator();
                myDirection = Direction.Counterclockwise;
            }

            if (LookingPoint.position == RailPoints[indicator].position)
            {
                SetPriorIndicator();
                myDirection=Direction.Counterclockwise;
            }
            LookingPoint.position = Vector3.MoveTowards(LookingPoint.position, RailPoints[indicator].position, Mathf.Abs(distance) * sensitivity);
        }
    }
    void SetNextIndicator() {
        if (indicator < RailPoints.Count-1) {
            indicator++;
            return;
        }

        if (indicator == RailPoints.Count-1)
        {
            indicator=0;
            return;
        }
    }
    void SetPriorIndicator()
    {
        if (indicator > 0)
        {
            indicator--;
            return;
        }
        if (indicator ==0 ) {
            indicator = RailPoints.Count-1;
            return;
        }
    }
}
