using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    int x, y;
    public int Row = 1, Line=1 ;

    float _timePassed;
    public float _spawnInterval;
    public float _lengthToMove;
    public GameObject GO_Indicator;
    public List<GameObject> _bufferList;
    Vector3 _originalPos;
    StockPileManager _stockPileInstance;
    private void Awake()
    {

        _originalPos = GO_Indicator.transform.position;
        _stockPileInstance = GetComponent<StockPileManager>();
        GO_Indicator.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnEnable()
    {
        _stockPileInstance.OnDeposit += addToBufferList;
        //_stockPileInstance.OnWithDraw += addToBufferList;
    }

    private void OnDisable()
    {
        _stockPileInstance.OnDeposit -= addToBufferList;

    }
    // Update is called once per frame
    void Update()
    {

        if (_bufferList.Count>0) {
            doRainFallEffect();
        }
        
    }

    void addToBufferList(int amount) {
        for (int i = 0; i < amount; i++)
        {
            _bufferList.Add(Instantiate(GO_Indicator,gameObject.transform));
        }

       
    }

    void doRainFallEffect()
    {
        if (_timePassed > _spawnInterval)
        {
            GO_Indicator.transform.position = _originalPos + new Vector3(-_lengthToMove * y, 0, _lengthToMove * x);

            var go = _bufferList[_bufferList.Count - 1];
            go.GetComponent<Rigidbody>().isKinematic = false;
            go.GetComponent<Transform>().position = GO_Indicator.transform.position;
            go.GetComponent<BoxCollider>().enabled = true;
            go.GetComponent<MeshRenderer>().enabled = true;
            go.AddComponent<EnableIsKinematicAfterTime>();
            go.name = "Tile X:" +x+"/Y:" + y+ " "+gameObject.GetComponentsInChildren<Transform>().Length;

            x++;
            if (x == Row)
            {
                x = 0;
                y++;
            }
            if (y == Line)
            {
                y = 0;
            }

            _bufferList.RemoveAt(_bufferList.Count - 1);
            _timePassed = 0;
        }
        _timePassed += Time.deltaTime;

    }
}
