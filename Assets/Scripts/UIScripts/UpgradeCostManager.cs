using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCostManager : MonoBehaviour
{
    TMPro.TextMeshProUGUI textGUI;
    
    private void Awake()
    {
        textGUI = this.GetComponent<TMPro.TextMeshProUGUI>();
        updateTxt();
    }


    private void OnEnable()
    {
        SimpleGameEvents.OnUI_TXT_Change += updateTxt;
    }
    private void OnDisable()
    {
        SimpleGameEvents.OnUI_TXT_Change -= updateTxt;

    }

    private void updateTxt()
    {
        textGUI.text = "Increase damage(<color=#FFBD33>" +
            GameMasterManager.GMMInstance.myStats.Damage.ToString()
            + "</color>) by 1";
    }
}
