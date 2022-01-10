using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldTXTManager : MonoBehaviour
{
    TMPro.TextMeshProUGUI textGUI;
    readonly string prefix = "Gold in bank:";
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

    private void updateTxt()
    {
        textGUI.text = prefix + "(<color=#FFC300>" + GameMasterManager.GMMInstance.myStats.Gold.ToString()+ "</color>)";
    }
}
