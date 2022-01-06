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
    // Update is called once per frame
    void Update()
    {
        if (CanPlay) { 

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SimpleGameEvents.OnPickAxeRelease?.Invoke();
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
