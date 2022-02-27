using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPointManager : MonoBehaviour
{
    public Action OnDestinationReached;

    public Vector3 TargetPosition;
    public Vector3 CurrentPosition;
    public float Speed, SpeedCarrying;//Set from PeopleManager when Instatiating

    public PeopleManager MyPeopleManager;
    private WorkerManager _myStateMachine;
    
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

    void Update()
    {
        if (CurrentPosition != TargetPosition) {
            var currSpeed = Speed;
            var orders = _myStateMachine.GetCurrentOrders();
            //Going to consumer means that the worker is already carrying objects;
            if (orders != null && orders.CurrentStage == TransferOrder.TranferStage.GoingToConsumer) {
                currSpeed = SpeedCarrying;
            }


            gameObject.transform.position= Vector3.MoveTowards(gameObject.transform.position, TargetPosition, currSpeed * Time.deltaTime);
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


    //------------getset-------------
    public bool GetIsMoving() {
        return _isMovingTowards;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(gameObject.transform.position, TargetPosition);
        Gizmos.DrawSphere(TargetPosition, 0.15f);
    }
    //void lerpBetweenPotitions() {
    //    gameObject.transform.localPosition = Vector3.Slerp(CurrentPosition, TargetPosition, Time.deltaTime / Speed);
    //}

    
}
