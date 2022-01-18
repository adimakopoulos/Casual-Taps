using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyListenerManager : MonoBehaviour
{
    bool CanPlay;
    

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

    Vector3 StartMousePos;
    float ignoreThisDistance=100f;//Player should releas the click AT LEAST 100 pixels Away in order to move the camera
    void Update()
    {

        //the hole premiss of the game. player presses Button and breaks a tile.
        //TODO: check for UI press
        if (CanPlay) {

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                SimpleGameEvents.OnPickAxeRelease?.Invoke();
            }
            
        }

        //Player wants to look left and right
        if (Input.GetMouseButtonDown(0))
        {
            StartMousePos = Input.mousePosition;


        }
        if (Input.GetMouseButtonUp(0))
        {
            var CurrMousePos = Input.mousePosition;
            if (CurrMousePos.x > StartMousePos.x+ ignoreThisDistance) {
                Debug.Log("Right");
                SimpleGameEvents.OnLookLeft?.Invoke();
            }
            if (CurrMousePos.x < StartMousePos.x- ignoreThisDistance)
            {
                Debug.Log("Left");
                SimpleGameEvents.OnLookRight?.Invoke();
            }

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
