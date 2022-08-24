using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtManager : MonoBehaviour
{

    public List<Transform> LookTargets;
    public enum CameraLookType {LookingAtMiningPosition, LookingAtRailSystem };
    public static CameraLookType currLookType ;

    //TODO: Make this an Enum so i can understand what the player looks at in Context
    public int currLookingPosition ;
    Cinemachine.CinemachineVirtualCamera myCamera;
    Cinemachine.CinemachineFramingTransposer myFramingTransposer;

    private Transform lastSpawnedTileTransform;
    private void Awake()
    {
        myCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
        myFramingTransposer = myCamera.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>();
        
        myCamera.LookAt = LookTargets[1];
        myCamera.Follow = LookTargets[1];

        currLookingPosition = 1;
        currLookType = CameraLookType.LookingAtMiningPosition;
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
        SimpleGameEvents.OnTileDestroyed += lookAtTilesDeathLocation;
        SimpleGameEvents.OnNewTileSpawned += lookAtSpawnedTile;
        SimpleGameEvents.OnNewTileSpawned += setLastSpawnedTileTransform;


    }
    private void OnDisable()
    {
        SimpleGameEvents.OnLookLeft -= LookLeft;
        SimpleGameEvents.OnLookRight -= LookRight;
        SimpleGameEvents.OnLookDown -= LookAtRail;
        SimpleGameEvents.OnLookUp -= LookAtDrill;
        SimpleGameEvents.OnTileDestroyed -= lookAtTilesDeathLocation;
        SimpleGameEvents.OnNewTileSpawned -= lookAtSpawnedTile;
        SimpleGameEvents.OnNewTileSpawned -= setLastSpawnedTileTransform;




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
        if (!(currLookingPosition - 1 < 0)&& currLookType == CameraLookType.LookingAtMiningPosition)
        {
            currLookingPosition--;
            lookAtPositionFromTheListOfTargets();
        }
    }
    private void LookRight()
    {
        if (!(currLookingPosition + 1 > LookTargets.Count - 1)&& currLookType == CameraLookType.LookingAtMiningPosition && !(currLookingPosition==2))
        {
            currLookingPosition++;
            lookAtPositionFromTheListOfTargets();
        }
    }

    private void lookAtPositionFromTheListOfTargets()
    {
        int currentNumOfTilesInList = TileStack.StackOTiles.Count;
        lookAtLastTileFromTileList(currentNumOfTilesInList);
        lookAtLastSpawnedTileOrDefaultMiningPosition(currentNumOfTilesInList);
        lookAtInvetoryPositionOrShopPosition();

    }

    private void lookAtInvetoryPositionOrShopPosition()
    {
        if (currLookingPosition != 1)
        {
            myCamera.LookAt = LookTargets[currLookingPosition];
            myCamera.Follow = LookTargets[currLookingPosition];
            SimpleGameEvents.OnPlayerCurrentlyLookingAt?.Invoke(currLookingPosition);

        }
    }

    private void lookAtLastSpawnedTileOrDefaultMiningPosition(int currentNumOfTilesInList)
    {
        if (currLookingPosition == 1 && currentNumOfTilesInList <= 0)
        {
            if (lastSpawnedTileTransform != null)
            {

                myCamera.LookAt = lastSpawnedTileTransform;
                myCamera.Follow = lastSpawnedTileTransform;
                SimpleGameEvents.OnPlayerCurrentlyLookingAt?.Invoke(currLookingPosition);
            }
            else
            {
                myCamera.LookAt = LookTargets[currLookingPosition];
                myCamera.Follow = LookTargets[currLookingPosition];
                SimpleGameEvents.OnPlayerCurrentlyLookingAt?.Invoke(currLookingPosition);
            }
        }
    }

    private void lookAtLastTileFromTileList(int currentNumOfTilesInList)
    {
        if (currLookingPosition == 1 && currentNumOfTilesInList > 0)
        {
            myCamera.LookAt = TileStack.StackOTiles[currentNumOfTilesInList - 1].gameObject.transform;
            myCamera.Follow = TileStack.StackOTiles[currentNumOfTilesInList - 1].gameObject.transform;
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
        currLookType = CameraLookType.LookingAtMiningPosition;
        myFramingTransposer.m_DeadZoneHeight = 0.16f;
        SimpleGameEvents.OnPlayerCurrentlyLookingAt?.Invoke(currLookingPosition);

    }

    private void lookAtSpawnedTile(Transform transform) {
        if (currLookType.Equals(CameraLookType.LookingAtMiningPosition)&& currLookingPosition==1) { 
            myCamera.LookAt = transform;
            myCamera.Follow = transform;
        }
    }
    private void lookAtTilesDeathLocation(TileManager tileManager) {
        myCamera.LookAt = tileManager.transform;
        myCamera.Follow = tileManager.transform;
    }

    private void setLastSpawnedTileTransform(Transform transform) {
        lastSpawnedTileTransform = transform;
    }
}
