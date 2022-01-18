using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenObject : MonoBehaviour
{

    //public LeanTweenType Type;
    bool isHidden;

    RectTransform[] rectTransforms;
    float distance = 0;
    private void Awake()
    {
        rectTransforms = gameObject.GetComponentsInChildren<RectTransform>();
        if (rectTransforms == null)
        {
            Debug.Log(gameObject.name + "null RectTransform[]");
        }
        else {

            if (rectTransforms.Length == 0) {
                Debug.Log(gameObject.name + "Array is empty");
            } 
            else if(rectTransforms.Length > 0)
            {
                foreach (var rt in rectTransforms)
                {
                    if (distance< rt.sizeDelta.x) {
                        distance = rt.sizeDelta.x;
                    }
                }
            }
        }


        hideImmediately();
    }


    private void OnEnable()
    {
        SimpleGameEvents.OnLevelComplete += hide;
        SimpleGameEvents.OnStartGameplay += unhide;
    }

    private void OnDisable()
    {
        SimpleGameEvents.OnLevelComplete -= hide;
        SimpleGameEvents.OnStartGameplay -= unhide;
    }

    private void hide()
    {
        if (!isHidden)
        {
            isHidden = true;
            //LeanTween.moveLocalY(gameObject, distance, 3f).setEase(Type);
        }
    }
    private void unhide()
    {
        if (isHidden)
        {
            isHidden = false;
            //LeanTween.moveLocalY(gameObject, 0, 3f).setEase(Type);
        }
    }

    private void hideImmediately()
    {
        if (!isHidden)
        {
            isHidden = true;
            //LeanTween.moveLocalY(gameObject, distance, 0.001f).setEase(Type);
        }
    }
}
