using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillateOnYAxis : MonoBehaviour
{

    private MoveToPointManager moveManager;
    private Vector3 originalLocalScale;
    public float Distance;
    private void Awake()
    {
        moveManager = GetComponentInParent<MoveToPointManager>();
        moveManager.GetIsMoving();
        originalLocalScale = gameObject.transform.localScale;
    }
    private void OnEnable()
    {
        moveManager.OnDestinationReached += setOriginal;
    }
    private void OnDisable()
    {
        moveManager.OnDestinationReached -= setOriginal;

    }



    // Update is called once per frame
    void Update()
    {
        //var isMoving = moveManager.GetIsMoving();
        //if (isMoving)
            Oscillate();


    }

    Vector3 newLocalPos;
  
    void Oscillate()
    {

        var variance = Mathf.Sin(Time.time * 17f);


        newLocalPos = new Vector3(transform.localScale.x , transform.localScale.y , transform.localScale.z + variance*0.35f);
        gameObject.transform.localScale = newLocalPos;
    }

    void setOriginal()
    {
        gameObject.transform.localScale = originalLocalScale;
    }

}
