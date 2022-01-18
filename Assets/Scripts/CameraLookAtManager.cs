using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtManager : MonoBehaviour
{

    public List<Transform> LookTargets;
    public int currLookingPosition ;
    Cinemachine.CinemachineVirtualCamera myCamera;
    private void Awake()
    {
        myCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
        myCamera.LookAt = LookTargets[1];
        currLookingPosition = 1;
    }

    private void OnEnable()
    {
        SimpleGameEvents.OnLookLeft += LookLeft;
        SimpleGameEvents.OnLookRight += LookRight;

    }
    private void OnDisable()
    {
        SimpleGameEvents.OnLookLeft -= LookLeft;
        SimpleGameEvents.OnLookRight -= LookRight;
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
        if (!(currLookingPosition - 1 < 0))
        {
            currLookingPosition--;
            myCamera.LookAt = LookTargets[currLookingPosition];
            myCamera.Follow = LookTargets[currLookingPosition];
        }
    }
    private void LookRight()
    {

        if (!(currLookingPosition + 1 > LookTargets.Count - 1))
        {
            currLookingPosition++;
            myCamera.LookAt = LookTargets[currLookingPosition];
            myCamera.Follow = LookTargets[currLookingPosition];
        }

    }


}
