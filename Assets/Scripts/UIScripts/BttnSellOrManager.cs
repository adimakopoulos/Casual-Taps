using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BttnSellOrManager : MonoBehaviour
{
    TMPro.TextMeshProUGUI textGUI;
    UnityEngine.UI.Button bttnBuy;

    private void Awake()
    {
        bttnBuy = this.GetComponent<UnityEngine.UI.Button>();
        textGUI = this.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        bttnBuy.onClick.AddListener(OnMouseClickUP);
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

    private void OnMouseClickUP()
    {
        var oreGathered = GameMasterManager.GMMInstance.myStats.IronOre;
        var orePrice = GameMasterManager.GMMInstance.myShop.sellOrePrice;
        if (oreGathered >= orePrice) {
            GameMasterManager.GMMInstance.myStats.IronOre -= orePrice;
            GameMasterManager.GMMInstance.myStats.Coins ++;
            SimpleGameEvents.OnUI_TXT_Change?.Invoke();
        }

    }

    private void updateTxt()
    {
        textGUI.text = "Sell (<color=#C70039>" + GameMasterManager.GMMInstance.myShop.sellOrePrice+ "</color>) Iron ore for(<color=#FFC300>" + "1</color>) gold coin";
    }
}
