using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ButtonDeleteProgress : MonoBehaviour
{
    UnityEngine.UI.Button bttnDeleteProgress;
    private void Awake()
    {
        bttnDeleteProgress = this.GetComponent<UnityEngine.UI.Button>();
        bttnDeleteProgress.onClick.AddListener(DeleteLocalProgress);
    }

    void DeleteLocalProgress() {
        JsonManager.DeleteProgress();
    }
}
