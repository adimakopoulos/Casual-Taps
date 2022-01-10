using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenObject : MonoBehaviour
{

    public LeanTweenType Type;
    bool isHidden;
    private void Awake()
    {
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
            LeanTween.moveLocalY(gameObject, 100f, 3f).setEase(Type);
        }
    }
    private void unhide()
    {
        if (isHidden)
        {
            isHidden = false;
            LeanTween.moveLocalY(gameObject, 0, 3f).setEase(Type);
        }
    }

    private void hideImmediately()
    {
        if (!isHidden)
        {
            isHidden = true;
            LeanTween.moveLocalY(gameObject, 100f, 0.1f).setEase(Type);
        }
    }
}
