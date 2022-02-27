using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
    public Transform StartPos,EndPos;
    float time = 0f;
    float duration = 5f;
    public enum State {GoingUp, GoingDown ,Loading,Unloading}
    public State state;
    public Action<State> OnStateChanged;
    private StockPileManager mySPM;
    public PlacementManager myPM;
    private void Awake()
    {
        StartCoroutine(LerpFuncEndToStart());
        mySPM = GetComponent<StockPileManager>();
        myPM = GetComponent<PlacementManager>();
    }

    private void OnEnable()
    {
        //myPM.OnStoredSuccesfully += goToEnd;
        myPM.OnStoredSuccesfully += goToEnd;
        mySPM.OnWithDraw += goToStart;
    }
    private void OnDisable()
    {
        myPM.OnStoredSuccesfully += goToEnd;
        mySPM.OnWithDraw -= goToStart;
    }

    void goToEnd() {
        if (mySPM.GetAvailableStorage() == 0) {
            time = 0;
            StartCoroutine(LerpFuncStartToEnd());
        }
           
    }
    void goToStart(int a) {
        var currTotal = mySPM.myStockPileData.getCurentTotal();
        if (0 == currTotal) {
            time = 0;
            StartCoroutine(LerpFuncEndToStart());

        }
            
    }

    private IEnumerator LerpFuncStartToEnd() {
        state = State.GoingUp;
        OnStateChanged?.Invoke(state);
        while (time < duration)
        {
            transform.position = Vector3.Lerp(StartPos.position, EndPos.position, time / duration);
            time += Time.deltaTime;
            yield return null;

        }
        
        state = State.Unloading;
        OnStateChanged?.Invoke(state);
    }
    private IEnumerator LerpFuncEndToStart()
    {
        state = State.GoingDown;
        OnStateChanged?.Invoke(state);
        while (time < duration)
        {
            transform.position = Vector3.Lerp(EndPos.position, StartPos.position, time / duration);
            time += Time.deltaTime;
            yield return null;

        }
        state = State.Loading;
        OnStateChanged?.Invoke(state);
    }
}
