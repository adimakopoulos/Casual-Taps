using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BttnBuyDamageManager : MonoBehaviour
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
        if (GameMasterManager.GMMInstance.myStats.Gold >= GameMasterManager.GMMInstance.myShop.Cost) {
            buyDamage(); 
        }
    }

    private void updateTxt()
    {
        textGUI.text = "Cost: (<color=#FFBD33>" +
            GameMasterManager.GMMInstance.myShop.Cost.ToString()
            + "</color>) gold.";
    }
    private void buyDamage() {

        GameMasterManager.GMMInstance.myShop.incrementUpgradeCost();
        GameMasterManager.GMMInstance.myStats.Damage += GameMasterManager.GMMInstance.myShop.UpgradeBonusDmg;
        SimpleGameEvents.OnUI_TXT_Change?.Invoke();
    }
}
