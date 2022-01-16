using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonQuit : MonoBehaviour
{
    UnityEngine.UI.Button bttnQuit;
    private void Awake()
    {
        //bttnBuy.onClick.AddListener(OnMouseClickUP);
        bttnQuit = this.GetComponent<UnityEngine.UI.Button>();
        bttnQuit.onClick.AddListener(quitApp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void quitApp() {
        Application.Quit();
    }
}
