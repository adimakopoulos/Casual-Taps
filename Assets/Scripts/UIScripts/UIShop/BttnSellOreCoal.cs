using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BttnSellOreCoal : MonoBehaviour
{

    public TMPro.TextMeshProUGUI MiddleText;
    public TMPro.TextMeshProUGUI TopRightText;
    private  UnityEngine.UI.Button BttnObject;


    private void Awake()
    {
        BttnObject = this.GetComponent<UnityEngine.UI.Button>();
        BttnObject.onClick.AddListener(OnMouseClickUP);
    }

    private void OnMouseClickUP()
    {
        
        throw new NotImplementedException();
    }
}
