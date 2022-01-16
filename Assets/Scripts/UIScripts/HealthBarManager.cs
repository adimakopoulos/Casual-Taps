using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public static Action<float> OnBarResized;
    public RawImage rawImage;
    TMPro.TextMeshProUGUI textMesh;

    float x, y;
    Vector2 newSize;
    private void Awake()
    {
        textMesh = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        x = rawImage.rectTransform.sizeDelta.x;
        y = rawImage.rectTransform.sizeDelta.y;
    }

    private void OnEnable()
    {
        SimpleGameEvents.OnPickAxeImpact += setSize;
        SimpleGameEvents.OnPickAxeRelease += setSize;
    }
    private void OnDisable()
    {
        SimpleGameEvents.OnPickAxeImpact -= setSize;
        SimpleGameEvents.OnPickAxeRelease -= setSize;
    }

    private void setSize(TileManager tile)
    {
        var healthNormalized = (float)tile.Health / tile.MaxHealth;
        newSize = new Vector2(healthNormalized * x, y);
        rawImage.rectTransform.sizeDelta = newSize;
        textMesh.text = tile.Health + "/"+tile.MaxHealth;
        OnBarResized?.Invoke(newSize.x);


    }
    private void setSize()
    {
        var count = TileStack.StackOTiles.Count;
        if (count > 0) {
            var tile = TileStack.StackOTiles[count-1];
            var healthNormalized = (float)tile.Health / tile.MaxHealth;
            newSize = new Vector2(healthNormalized * x, y);
            rawImage.rectTransform.sizeDelta = newSize;
            textMesh.text = tile.Health + "/" + tile.MaxHealth;
            OnBarResized?.Invoke(newSize.x);
        
        }
    }
}

