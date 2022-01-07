using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    [SerializeField] RawImage bg;
    [SerializeField] RawImage Indicator;
    [SerializeField] RawImage healthColor;
    [RangeAttribute(0, 1)] float percetage= 1;
    public TMPro.TextMeshProUGUI textMesh;
    Vector2 lastIndPos;
    float timePassed = 0;
    /// <summary>
    /// The rate of change for the Size Width Attribute. 
    /// If rate = 1 then it will take 1 second to take the targeted size.
    /// If rate = 0.5 it will need 2 seconds to reach the target size.
    /// </summary>
    [RangeAttribute(0f, 2f)]  public float rate = 1f;

    public LeanTweenType easeType;
    Vector2  BackColorSize;
    private void Awake()
    {
        //cashe size of RawImage.
        BackColorSize = bg.rectTransform.sizeDelta;
        //LeanTween.moveLocalX(gameObject, 10f, 2f).setEase(easeType);
        //LeanTween.moveX(gameObject, 10f, 4f);
        //LeanTween.scale(gameObject, Vector3.zero, 2).setOnComplete();
    }
    void Update()
    {
        if(timePassed < 2f)
            timePassed += Time.deltaTime*rate;
       
        var deltaSize = Mathf.Lerp(lastIndPos.x, BackColorSize.x * percetage, timePassed);
        Vector2 newSize = new Vector2(deltaSize, BackColorSize.y);




        //Health color changes size instantly to the calculated percentage.
        healthColor.rectTransform.sizeDelta = new Vector2(BackColorSize.x * percetage, BackColorSize.y);
        //set the lerped size for Difference indicator
        Indicator.rectTransform.sizeDelta = newSize;
    }
    private void OnEnable()
    {
        SimpleGameEvents.OnPickAxeImpact += updateTxt;
        SimpleGameEvents.OnTileDestroy += getNextTileHealth;
    }
    private void OnDisable()
    {
        SimpleGameEvents.OnPickAxeImpact -= updateTxt;
        SimpleGameEvents.OnTileDestroy -= getNextTileHealth;
    }

    private void updateTxt(TileManager tm) {
        lastIndPos = Indicator.rectTransform.sizeDelta;
        timePassed = 0;
        percetage =   (float)tm.Health / tm.MaxHealth;
        textMesh.text = "HP: " + tm.Health.ToString() + "/" + tm.MaxHealth.ToString();
    }
    private void getNextTileHealth(TileManager a) {
        var index = TileStack.StackOTiles.Count-1;
        if (index < 0) {
            return;
        }
        else {
            updateTxt(TileStack.StackOTiles[index]);

        }
        
        //percetage = (float)tm.Health / tm.MaxHealth;
    }
}
