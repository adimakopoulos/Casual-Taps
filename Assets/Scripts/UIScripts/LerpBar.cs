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
    float Xscale, Yscale, currentX_Scale;
    
    private void Awake()
    {
        currentX_Scale = rawImage.rectTransform.localScale.x;
        Xscale = rawImage.rectTransform.localScale.x;
        Yscale = rawImage.rectTransform.localScale.y;
        LocalScale = new Vector2(Xscale, Yscale);
    }

    private void OnEnable()
    {
        HealthBarManager.OnBarResized += doLerp;
    }


    private void OnDisable()
    {
        HealthBarManager.OnBarResized -= doLerp;
    }
    Vector2 LocalScale;
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
            rawImage.rectTransform.localScale = new Vector2(Mathf.Lerp(currentX_Scale, LocalScale.x, elaspedDeltaTime / duration), Yscale);
            
        }
  

 
        
    }


    private void doLerp(float targetXScaLe) {
        if(elaspedDeltaTime > duration)//if the Indicator bar is already learping, ignore delay
            delay = delayLength;

        elaspedDeltaTime = 0f;
        currentX_Scale = rawImage.rectTransform.localScale.x;
        LocalScale = new Vector2(targetXScaLe, Yscale);

        // When the health bar increases in size it means that 
        //1. the tile has healed or 
        //2. a new tile health has been set. 
        //meaning that the Indication bar is not visible because the health bar is set instantly, covering this one
        if (targetXScaLe < currentX_Scale) {
            duration = 0.7f;
        }
        else {
            duration = 0.1f;
        }
    }


}
