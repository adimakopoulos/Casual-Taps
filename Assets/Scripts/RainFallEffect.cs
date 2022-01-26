using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFallEffect : MonoBehaviour
{
    public GameObject TileBrokenGO;
    List<GameObject> _bufferList;
    int _loosePieces =0 ;
    public TileManager.TypeMetal MetalTypeStored;
    float _spawnInterval = 0.15f;
    Transform parentTransform;
    float _lengthToMove=0.67f;
    Vector3 _originalPos;
    private void Awake()
    {
        _originalPos = TileBrokenGO.transform.position;
        TileBrokenGO.GetComponent<MeshRenderer>().enabled = false;
        parentTransform = GetComponentInParent<Transform>();
        _bufferList = new List<GameObject>();
    }

    private void OnEnable()
    {
        StockpileManager.OnLoosePiecesProcessed += setList;
    }
    private void OnDisable()
    {
        StockpileManager.OnLoosePiecesProcessed -= setList;
    }
    // Update is called once per frame
    void Update()
    {

        if (_bufferList.Count > 0) {
            doRainFallEffect();
        }

        //foreach (var item in LoosePecies)
        //{

        //    //item.GetComponent<BoxCollider>().enabled = false;
        //    item.freezeRotation = true;
        //    item.gameObject.transform.position = TileBrokenGO.transform.position;
        //    item.gameObject.transform.rotation = TileBrokenGO.transform.rotation;
        //    item.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ
        //        | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;

        //}
    }

    public void getPiece() {
        _loosePieces++;
    }
    public void getPiece(int amount)
    {
        _loosePieces+= amount;
    }

    private void setList() {
        for (int i = 0; i < _loosePieces; i++)
        {
            var go = Instantiate(TileBrokenGO, parentTransform);
            _bufferList.Add(go);
        }
        _loosePieces = 0;
        
    }

    float _timePassed = 0f;
    int x=0,y= 0;
    void doRainFallEffect() {
        //TODO: not working, need refactoring;
        if (_timePassed> _spawnInterval) {
            TileBrokenGO.transform.position = _originalPos + new Vector3(-_lengthToMove * y, 0, _lengthToMove * x);

            var go = _bufferList[_bufferList.Count - 1];
            go.GetComponent<Rigidbody>().isKinematic = false;
            go.GetComponent<Transform>().position = TileBrokenGO.transform.position;
            go.GetComponent<BoxCollider>().enabled = true;
            go.GetComponent<MeshRenderer>().enabled = true;

            x++;
            if (x== 9)
            {
                x = 0;
                y++;
            }
            if (y == 9) 
            {
                y = 0; 
            } 

            //if (x == 9 ) {
            //    TileBrokenGO.transform.position = _originalPos;
                
            //    TileBrokenGO.transform.position -= new Vector3(_lengthToMove*y, 0, 0);
            //    y++;
            //    if (y>9)
            //    {
            //        y = 1;
            //        x = 1;
            //    }
            //}
            //x++;
            //y++;

            _bufferList.RemoveAt(_bufferList.Count - 1);
            _timePassed =0;
        }
        _timePassed+= Time.deltaTime;

    }


}
