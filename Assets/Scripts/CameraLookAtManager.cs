using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtManager : MonoBehaviour
{

    public List<Transform> LookTargets;
    public enum CameraLookType {LookingAtDrill, LookingAtRailSystem };
    public static CameraLookType currLookType ;

    //TODO: Make this an Enum so i can understand what the player looks at in Context
    public int currLookingPosition ;
    Cinemachine.CinemachineVirtualCamera myCamera;
    Cinemachine.CinemachineFramingTransposer myFramingTransposer;
    private void Awake()
    {
        myCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
        myFramingTransposer = myCamera.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>();
        
        myCamera.LookAt = LookTargets[1];
        currLookingPosition = 1;
        currLookType = CameraLookType.LookingAtDrill;
        foreach (Transform t in LookTargets) {
            if (LookTargets[1] == t)
                continue;
            t.gameObject.SetActive(false); 
        }
    }

    private void OnEnable()
    {
        SimpleGameEvents.OnLookLeft += LookLeft;
        SimpleGameEvents.OnLookRight += LookRight;
        SimpleGameEvents.OnLookDown += LookAtRail;
        SimpleGameEvents.OnLookUp += LookAtDrill;

    }
    private void OnDisable()
    {
        SimpleGameEvents.OnLookLeft -= LookLeft;
        SimpleGameEvents.OnLookRight -= LookRight;
        SimpleGameEvents.OnLookDown -= LookAtRail;
        SimpleGameEvents.OnLookUp -= LookAtDrill;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LookLeft()
    {
        if (!(currLookingPosition - 1 < 0)&& currLookType == CameraLookType.LookingAtDrill)
        {
            currLookingPosition--;
            myCamera.LookAt = LookTargets[currLookingPosition];
            myCamera.Follow = LookTargets[currLookingPosition];
            SimpleGameEvents.OnPlayerCurrentlyLookingAt?.Invoke(currLookingPosition);
        }
    }
    private void LookRight()
    {

        if (!(currLookingPosition + 1 > LookTargets.Count - 1)&& currLookType == CameraLookType.LookingAtDrill && !(currLookingPosition==2))
        {
            currLookingPosition++;
            myCamera.LookAt = LookTargets[currLookingPosition];
            myCamera.Follow = LookTargets[currLookingPosition];
            SimpleGameEvents.OnPlayerCurrentlyLookingAt?.Invoke(currLookingPosition);

        }

    }
    private void LookAtRail() {
        if (currLookingPosition ==1 )
        {
            currLookType = CameraLookType.LookingAtRailSystem;
            myCamera.LookAt = LookTargets[3];
            myCamera.Follow = LookTargets[3];
            myFramingTransposer.m_DeadZoneHeight = 0;
        }
    }
    private void LookAtDrill() {
        currLookingPosition=1;
        myCamera.LookAt = LookTargets[currLookingPosition];
        myCamera.Follow = LookTargets[currLookingPosition];
        currLookType = CameraLookType.LookingAtDrill;
        myFramingTransposer.m_DeadZoneHeight = 0.16f;
        SimpleGameEvents.OnPlayerCurrentlyLookingAt?.Invoke(currLookingPosition);

    }

}
