using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRestrictionManager : MonoBehaviour
{
    public Transform CameraTransform;
    public Transform TargetTrans;
    Transform _originalPos;
    public float ClosenessRatio;
    public float Y_Offset;
    private void Awake()
    {
        _originalPos = CameraTransform;
        Y_Offset = CameraTransform.position.y;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //the X Y Z attributs that are returned form Transform.position , are read only. so i have to set the vector3 
        CameraTransform.position = new Vector3(CameraTransform.position.x, Mathf.Lerp(CameraTransform.position.y, TargetTrans.position.y+Y_Offset, ClosenessRatio*Time.deltaTime), CameraTransform.position.z);
    }
}
