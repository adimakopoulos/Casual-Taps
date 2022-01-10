using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpBar : MonoBehaviour
{
    public RawImage rawImage;
    float x, y, currentX;
    private bool isLerping;
    
    private void Awake()
    {
        currentX = rawImage.rectTransform.sizeDelta.x;
        x = rawImage.rectTransform.sizeDelta.x;
        y = rawImage.rectTransform.sizeDelta.y;
    }

    private void OnEnable()
    {
        HealthBarManager.OnBarResized += doLerp;
        SimpleGameEvents.OnTileDestroy += refill;
    }


    private void OnDisable()
    {
        HealthBarManager.OnBarResized -= doLerp;
        SimpleGameEvents.OnTileDestroy -= refill;
    }
    Vector2 target;
    float deltaTime,duration = 0.5f;
    private void Update()
    {
        if (isLerping) {
            deltaTime += Time.deltaTime;
            rawImage.rectTransform.sizeDelta = new Vector2(Mathf.Lerp(currentX, target.x, deltaTime/duration),y);

            if (deltaTime > duration) {
                isLerping = false;
                deltaTime = 0f;
                currentX = target.x;
            }
        }
    }


    private void doLerp(float targetX) {
        if (!isLerping)
        {
            deltaTime = 0f;
            isLerping = true;
            target = new Vector2(targetX, y);
        }


    }

    float refillDelay=2f;
    private void refill(TileManager obj)
    {

        doLerp(x);
    }
}
