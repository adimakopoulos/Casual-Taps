using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTextManager : MonoBehaviour
{
    TMPro.TextMeshProUGUI textGui;
    private void Awake()
    {
        textGui = GetComponent<TMPro.TextMeshProUGUI>(); 
    }

    private void OnEnable()
    {
        SimpleGameEvents.OnHasTileTakenDamage += updateTxt;
    }
    private void OnDisable()
    {
        SimpleGameEvents.OnHasTileTakenDamage -= updateTxt;

    }

    void updateTxt(TileManager tile) {
        
        textGui.text = "" + tile.Health + "/" + tile.MaxHealth;

    }


}
