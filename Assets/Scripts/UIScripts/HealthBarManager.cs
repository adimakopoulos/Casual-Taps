using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public static Action <float>OnBarResized;
    public RawImage rawImage;


    float x, y;
    Vector2 newSize;
    private void Awake()
    {
        x = rawImage.rectTransform.sizeDelta.x;
        y = rawImage.rectTransform.sizeDelta.y;
    }

    private void OnEnable()
    {
        SimpleGameEvents.OnPickAxeImpact += setSize;
    }
    private void OnDisable()
    {
        SimpleGameEvents.OnPickAxeImpact -= setSize;

    }

    private void setSize(TileManager tile) {
        var healthNormalized = (float)tile.Health / tile.MaxHealth;
        newSize = new Vector2(healthNormalized*x,y);
        rawImage.rectTransform.sizeDelta = newSize;
        OnBarResized?.Invoke(newSize.x);


    }
}

