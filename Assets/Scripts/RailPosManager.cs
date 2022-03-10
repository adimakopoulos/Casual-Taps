using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailPosManager : MonoBehaviour
{

    public List<Transform> RailPointsLeft;
    public List<Transform> RailPointsRight;
    public Transform LookingPoint;
    private void Awake()
    {
        foreach (Transform t in RailPointsLeft) { 
            var r = t.gameObject.GetComponent<Renderer>();
            if (r != null) {r.enabled = false;}
        }
        foreach (Transform t in RailPointsRight)
        {
            var r = t.gameObject.GetComponent<Renderer>();
            if (r != null) { r.enabled = false; }
        }
        LookingPoint.position = RailPointsLeft[0].position;
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
    private enum Direction { Left, Right }
    private Direction myDirection, CurrentlyMoving;
    private float sensitivity = 0.051f;
    bool hasSwitched;
    void MoveLookedObject(Vector3 mouseDelta) {
        //If the camera is looking at the Drill movement, return.
        if (CameraLookAtManager.currLookType == CameraLookAtManager.CameraLookType.LookingAtDrill) {
            return;
        }
        var distance = mouseDelta.x+ mouseDelta.y;

        //If player is looking at the starting point, Decide Where to go
        if (LookingPoint.position == RailPointsLeft[0].position) {

            if (distance < 0)
                myDirection = Direction.Left;
            if (distance > 0)
                myDirection = Direction.Right;
        }




        //Debug.Log("We are going left side" + distance);
        if (myDirection == Direction.Left )
        {
            if (distance < 0 && (LookingPoint.position == RailPointsLeft[indicator].position || CurrentlyMoving == Direction.Right)) {  
                SetNextIndicator(RailPointsLeft);
                CurrentlyMoving = Direction.Right;
                //return;
            }
               
               
            if (distance > 0 && (LookingPoint.position == RailPointsLeft[indicator].position || CurrentlyMoving == Direction.Left)) {
                SetPriorIndicator();
                CurrentlyMoving = Direction.Left;
                //return;
            }


        }

        //Debug.Log("We are going right side" + distance);
        if (myDirection == Direction.Right)
        {
            if (distance > 0 && (LookingPoint.position == RailPointsRight[indicator].position || CurrentlyMoving == Direction.Left))
            {
                CurrentlyMoving = Direction.Left;
                SetNextIndicator(RailPointsRight);

            }


            if (distance < 0 && (LookingPoint.position == RailPointsRight[indicator].position || CurrentlyMoving == Direction.Right))
            {
                CurrentlyMoving = Direction.Right;
                SetPriorIndicator();
                
            }
        }

        if (distance < 0)
            CurrentlyMoving = Direction.Left;
        if (distance > 0)
            CurrentlyMoving = Direction.Right;
        moveStaredCameraObject(distance);
    }
    void SetNextIndicator(List<Transform> list) {
        if (indicator+1 <= list.Count-1) {
            indicator++;
        }
        
    }
    void SetPriorIndicator()
    {
        if (indicator - 1 >= 0)
        {
            indicator--;
        }
        
    }
    void moveStaredCameraObject(float distance) {
        if (myDirection == Direction.Left)
        {
            LookingPoint.position = Vector3.MoveTowards(LookingPoint.position, RailPointsLeft[indicator].position, Mathf.Abs(distance) * sensitivity);
            return;
        }
        if (myDirection == Direction.Right)
        {
            LookingPoint.position = Vector3.MoveTowards(LookingPoint.position, RailPointsRight[indicator].position, Mathf.Abs(distance) * sensitivity);
            return;
        }
        
    }
}
