using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashBoardTxt : MonoBehaviour
{
    public TMPro.TextMeshProUGUI _myText;
    void Start()
    {
        _myText= gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        InventoryManager.OnInvetoryChange += updateTxt;
    }
    private void OnDisable()
    {
        InventoryManager.OnInvetoryChange -= updateTxt;
    }

    private void updateTxt(int Coal,int Gold,int Iron) {
        if (gameObject.name.Contains("Coal"))
            _myText.text = "Ore Stored:<br>" + Coal;
        if (gameObject.name.Contains("Gold"))
            _myText.text = "Ore Stored:<br>" + Gold;
        if (gameObject.name.Contains("Iron"))
            _myText.text = "Ore Stored:<br>" + Iron;
    }

}
