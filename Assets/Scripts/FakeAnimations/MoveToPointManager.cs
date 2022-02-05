using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPointManager : MonoBehaviour
{
    
    public Vector3 TargetPosition;
    public Vector3 CurrentPosition;
    public float Speed;
    public PeopleManager MyPeopleManager;
    private void Awake()
    {
        if (Speed ==0 ) {
            Debug.Log("Speed was 0, it has been changed to 2");
            Speed = 2;
        }
        CurrentPosition = gameObject.transform.localPosition;
    }
    private void OnEnable()
    {
        MyPeopleManager.OnNewTargetToMove += setTarget;
    }
    private void OnDisable()
    {
        MyPeopleManager.OnNewTargetToMove -= setTarget;
    }
    // Update is called once per frame
    void Update()
    {
        if (CurrentPosition != TargetPosition)  
            gameObject.transform.position= Vector3.MoveTowards(gameObject.transform.position, TargetPosition, Speed*Time.deltaTime);

        


    }

    private void setTarget(Vector3 target) {
        //target.y = 0;
        TargetPosition = target ;
        transform.LookAt(TargetPosition);
        


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(gameObject.transform.position, TargetPosition);
        Gizmos.DrawSphere(TargetPosition, 1f);
    }
    //void lerpBetweenPotitions() {
    //    gameObject.transform.localPosition = Vector3.Slerp(CurrentPosition, TargetPosition, Time.deltaTime / Speed);
    //}
}
