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


    Vector2 newSize;
    private void Awake()
    {
        textMesh = GetComponentInChildren<TMPro.TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        SimpleGameEvents.OnHasTileTakenDamage += setSize;
        SimpleGameEvents.OnPickAxeRelease += setSize;
    }
    private void OnDisable()
    {
        SimpleGameEvents.OnHasTileTakenDamage -= setSize;
        SimpleGameEvents.OnPickAxeRelease -= setSize;
    }

    private void setSize(TileManager tile)
    {
        var healthNormalized = (float)tile.Health / tile.MaxHealth;
        rawImage.rectTransform.localScale = new Vector2(healthNormalized, 1);
        textMesh.text = tile.Health + "/"+tile.MaxHealth;
        OnBarResized?.Invoke(healthNormalized);
    }
    private void setSize()
    {
        var count = TileStack.StackOTiles.Count;
        if (count > 0) {
            var tile = TileStack.StackOTiles[count-1];
            var healthNormalized = (float)tile.Health / tile.MaxHealth;
            rawImage.rectTransform.localScale = new Vector2(healthNormalized , 1);
            textMesh.text = tile.Health + "/" + tile.MaxHealth;
            OnBarResized?.Invoke(healthNormalized);
        
        }
    }
}

