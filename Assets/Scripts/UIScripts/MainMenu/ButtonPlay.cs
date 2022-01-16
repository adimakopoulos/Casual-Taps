using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    UnityEngine.UI.Button bttnPlay;
    
    private void Awake()
    {
        //bttnBuy.onClick.AddListener(OnMouseClickUP);
        bttnPlay = this.GetComponent<UnityEngine.UI.Button>();
        bttnPlay.onClick.AddListener(LoadScene);

        
    }
    private void Update()
    {
        if (SceneManager.GetSceneByName("GameRoom1").isLoaded)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("GameRoom1"));
        }
    }

    void LoadScene() {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

}
