using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreTXTManager : MonoBehaviour
{
    TMPro.TextMeshProUGUI textGUI;
    readonly string prefix = "Ore Gathered(";
    private void Awake()
    {
        textGUI = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
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

    private void updateTxt() {
        textGUI.text = prefix + "<color=#C70039>" + GameMasterManager.GMMInstance.myStats.IronOre.ToString()+ "</color>)";
    }
}

