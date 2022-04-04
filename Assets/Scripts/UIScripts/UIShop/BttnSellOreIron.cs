using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BttnSellOreIron : MonoBehaviour
{
    public TMPro.TextMeshProUGUI MiddleText;
    public TMPro.TextMeshProUGUI TopRightText;
    private UnityEngine.UI.Button BttnObject;


    private void Awake()
    {
        BttnObject = this.GetComponent<UnityEngine.UI.Button>();
    }
}
