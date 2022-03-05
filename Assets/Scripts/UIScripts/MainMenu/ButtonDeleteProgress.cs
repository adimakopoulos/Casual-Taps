using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ButtonDeleteProgress : MonoBehaviour
{
    UnityEngine.UI.Button bttnDeleteProgress;
    private void Awake()
    {
        //bttnBuy.onClick.AddListener(OnMouseClickUP);
        bttnDeleteProgress = this.GetComponent<UnityEngine.UI.Button>();
        bttnDeleteProgress.onClick.AddListener(DeleteLocalProgress);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeleteLocalProgress() {
        JsonManager.DeleteProgress();
    }
}
