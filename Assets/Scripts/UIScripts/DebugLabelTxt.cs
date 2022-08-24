using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DebugLabelTxt : MonoBehaviour
{
    static TMPro.TextMeshProUGUI textGUI;
    static int incr =1;

    private void Awake()
    {
        textGUI = this.GetComponent<TMPro.TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        //SimpleGameEvents.OnStartGameplay += updateTxt;
        //SimpleGameEvents.OnPickAxeImpact += ImpactTxt;
    }
    private void OnDisable()
    {
        //SimpleGameEvents.OnStartGameplay -= updateTxt;
        //SimpleGameEvents.OnPickAxeImpact -= ImpactTxt;
    }

    void Update() {
        //textGUI.text = " StackOTiles StackOTiles " + TileStack.StackOTiles.Count.ToString();
        //textGUI.text = IsPointerOverUIElement(GetEventSystemRaycastResults()) ? "Over UI" : "Not over UI" ;
    }
    private void updateTxt()
    {
        var str = "";
        foreach (var item in TileStack.StackOTiles)
        {
            str += "<br> N" +item.gameObject.name+" ID" +item.GetInstanceID();
        }
        textGUI.text = str + "<br> C"+TileStack.StackOTiles.Count;
    }
    private void ImpactTxt(TileManager tileManager) {
        textGUI.text = "Colided with: " + tileManager.name + "<br>" +
        "StackOTiles.Count: " + TileStack.StackOTiles.Count;
    }
    public static void updateTxt(string str) {
        textGUI.text = str+"<br> ."+incr++;
    }

    
}
