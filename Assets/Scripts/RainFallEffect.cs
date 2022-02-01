using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFallEffect : MonoBehaviour
{
    public GameObject GOtoSpawn;
    List<GameObject> _bufferList;
    int _loosePieces =0 ;
    //public TileManager.TypeMetal MetalTypeStored;
    float _spawnInterval = 0.05f;
    Transform _parentTransform;
    float _lengthToMove=0.67f;
    Vector3 _originalPos;
    private void Awake()
    {
        _originalPos = GOtoSpawn.transform.position;
        GOtoSpawn.GetComponent<MeshRenderer>().enabled = false;
        _parentTransform = GetComponentInParent<Transform>();
        _bufferList = new List<GameObject>();
    }

    private void OnEnable()
    {
        InventoryManager.OnLoosePiecesProcessed += setList;
    }
    private void OnDisable()
    {
        InventoryManager.OnLoosePiecesProcessed -= setList;
    }
    // Update is called once per frame
    void Update()
    {

        if (_bufferList.Count > 0) {
            doRainFallEffect();
        }

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
            var go = Instantiate(GOtoSpawn, _parentTransform);
            _bufferList.Add(go);
        }
        _loosePieces = 0;
        
    }

    float _timePassed = 0f;
    int x=0,y= 0;
    void doRainFallEffect() {
        //TODO: not working, need refactoring;
        if (_timePassed> _spawnInterval) {
            GOtoSpawn.transform.position = _originalPos + new Vector3(-_lengthToMove * y, 0, _lengthToMove * x);

            var go = _bufferList[_bufferList.Count - 1];
            go.GetComponent<Rigidbody>().isKinematic = false;
            go.GetComponent<Transform>().position = GOtoSpawn.transform.position;
            go.GetComponent<BoxCollider>().enabled = true;
            go.GetComponent<MeshRenderer>().enabled = true;
            go.AddComponent<EnableIsKinematicAfterTime>();

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

            _bufferList.RemoveAt(_bufferList.Count - 1);
            _timePassed =0;
        }
        _timePassed+= Time.deltaTime;

    }


}
