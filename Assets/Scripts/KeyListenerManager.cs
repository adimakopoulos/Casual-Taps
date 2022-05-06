using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyListenerManager : MonoBehaviour
{
    bool CanPlay;
    Vector3 lastMousePos;
    /// <summary>
    /// return delta x 
    /// </summary>
    public static Action<Vector3> OnMousePosChanged;
    private void Awake()
    {
        lastMousePos=Input.mousePosition;
    }
    private void OnEnable()
    {
        SimpleGameEvents.OnStartGameplay += enablePlayerKeyes;
        SimpleGameEvents.OnLevelComplete += dissablePlayerKeyes;
    }
    private void OnDisable()
    {
        SimpleGameEvents.OnStartGameplay -= enablePlayerKeyes;
        SimpleGameEvents.OnLevelComplete -= dissablePlayerKeyes;
    }

    public Vector3 StartMousePos;
    public Vector3 currMousePos;
    float ignoreThisDistance=250f;//Player should releas the click AT LEAST 100 pixels Away in order to move the camera
    float ignoreTimer = 0.1f;//Ignore Draging for this period of time, to avoid Jitters;
    void Update()
    {
        currMousePos = Input.mousePosition;
        //the hole premiss of the game. player presses Button and breaks a tile.
        //TODO: check for UI press
        if (CanPlay) {

            if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
            {
                if (CameraLookAtManager.currLookType == CameraLookAtManager.CameraLookType.LookingAtDrill) {
                    SimpleGameEvents.OnPickAxeRelease?.Invoke();
                }
                
            }
            
        }

        //Player wants to look left and right
        if (Input.GetMouseButtonDown(0))
        {
            StartMousePos = Input.mousePosition;
            DoRayCast();

        }

        //Listen iif player wants to jumb to locations.
        if (Input.GetMouseButtonUp(0))
        {
            ignoreTimer = 0.01f;

            var CurrMousePos = Input.mousePosition;
            if (CurrMousePos.x > StartMousePos.x+ ignoreThisDistance) {
                //Debug.Log("Right");
                SimpleGameEvents.OnLookLeft?.Invoke();
            }
            if (CurrMousePos.x < StartMousePos.x- ignoreThisDistance)
            {
                //Debug.Log("Left");
                SimpleGameEvents.OnLookRight?.Invoke();
            }
            if (CurrMousePos.y > StartMousePos.y + ignoreThisDistance)
            {
                //Debug.Log("OnLookDown");
                SimpleGameEvents.OnLookDown?.Invoke();
            }
            if (CurrMousePos.y < StartMousePos.y - ignoreThisDistance)
            {
                //Debug.Log("OnLookDown");
                SimpleGameEvents.OnLookUp?.Invoke();
            }

        }

        //Hanlde Drag
        if (Input.GetMouseButton(0)) {
            if (ignoreTimer > 0)
            {
                ignoreTimer -= Time.deltaTime;
                goto SkipToEnd;
            }
            var MouseDelta =  new Vector3(lastMousePos.x- Input.mousePosition.x, lastMousePos.y- Input.mousePosition.y, lastMousePos.z- Input.mousePosition.z);
            OnMousePosChanged?.Invoke(MouseDelta);
            SkipToEnd: ;
            //Debug.Log("CurrMousePos" + MouseDelta);
        }


        lastMousePos = Input.mousePosition;
    }

    private void DoRayCast()
    {
        float range = 200f;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit,range);
         { 
            var target = hit.collider.gameObject;
            //TODO: if(EventSystem.current.IsPointerOverGameObject())  
                SimpleGameEvents.OnRaycastDone?.Invoke(target);
         }
        
    }

    private void enablePlayerKeyes() {

        CanPlay = true;
    }

    private void dissablePlayerKeyes()
    {

        CanPlay = false;
    }
}
