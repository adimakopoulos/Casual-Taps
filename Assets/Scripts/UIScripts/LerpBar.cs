using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// LerpBar handles the secondary bar, behind the hp bar. it does a small "animation" trying to reach the health bars size
/// </summary>
public class LerpBar : MonoBehaviour
{
    public RawImage rawImage;
    float x, y, currentX;
    
    private void Awake()
    {
        currentX = rawImage.rectTransform.sizeDelta.x;
        x = rawImage.rectTransform.sizeDelta.x;
        y = rawImage.rectTransform.sizeDelta.y;
        target = new Vector2(x, y);
    }

    private void OnEnable()
    {
        HealthBarManager.OnBarResized += doLerp;
    }


    private void OnDisable()
    {
        HealthBarManager.OnBarResized -= doLerp;
    }
    Vector2 target;
    float elaspedDeltaTime,duration = 0.7f;
    float delay=1f;
    float delayLength = 1f;
    private void Update()
    {

        if (elaspedDeltaTime < duration) {
            if (delay>0) {
                delay -= Time.deltaTime;
                return;
            }

            elaspedDeltaTime += Time.deltaTime;
            rawImage.rectTransform.sizeDelta = new Vector2(Mathf.Lerp(currentX, target.x, elaspedDeltaTime / duration), y);

        }
  

 
        
    }


    private void doLerp(float targetX) {
        if(elaspedDeltaTime > duration)//if the Indicator bar is already learping, ignore delay
            delay = delayLength;

        elaspedDeltaTime = 0f;
        currentX = rawImage.rectTransform.sizeDelta.x;
        target = new Vector2(targetX, y);

        // When the health bar increases in size it means that 
        //1. the tile has healed or 
        //2. a new tile health has been set. 
        //meaning that the Indication bar is not visible because the health bar is set instantly, covering this one
        if (targetX < currentX) {
            duration = 0.7f;
        }
        else {
            duration = 0.1f;
        }
    }


}
