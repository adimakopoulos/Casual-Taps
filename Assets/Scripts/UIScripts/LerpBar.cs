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
    float deltaTime,duration = 0.7f;
    float delay=2;
    private void Update()
    {
        if (deltaTime < duration) {
            deltaTime += Time.deltaTime;
            rawImage.rectTransform.sizeDelta = new Vector2(Mathf.Lerp(currentX, target.x, deltaTime / duration), y);

        }
  

 
        
    }


    private void doLerp(float targetX) {
        deltaTime = 0f;
        currentX = rawImage.rectTransform.sizeDelta.x;
        target = new Vector2(targetX, y);
    }


}
