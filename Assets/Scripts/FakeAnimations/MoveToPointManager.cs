using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPointManager : MonoBehaviour
{
    
    public Vector3 TargetPosition;
    public Vector3 CurrentPosition;
    public float Speed, SpeedCarrying;//Set from PeopleManager when Instatiating

    public PeopleManager MyPeopleManager;
    private WorkerManager _myStateMachine;
    public Action OnDestinationReached;
    private bool _isMovingTowards;
    private void Awake()
    {
        _myStateMachine = GetComponent<WorkerManager>();
        CurrentPosition = gameObject.transform.localPosition;
    }
    private void OnEnable()
    {
        _myStateMachine.OnNewDestination += setTarget;
    }
    private void OnDisable()
    {
        _myStateMachine.OnNewDestination -= setTarget;
    }
    // Update is called once per frame
    void Update()
    {
        if (CurrentPosition != TargetPosition) {
            gameObject.transform.position= Vector3.MoveTowards(gameObject.transform.position, TargetPosition, Speed*Time.deltaTime);
            CurrentPosition = gameObject.transform.position;
            return;
        }
        if (_isMovingTowards && CurrentPosition == TargetPosition) {
            _isMovingTowards = false;
            OnDestinationReached?.Invoke();
            
        }

        


    }

    private void setTarget(Vector3 target) {
        _isMovingTowards = true;
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
