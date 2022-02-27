using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/// <summary>
/// Spawns a number of Prefabs and stores them in a list.
/// It moves a game object by a certain lenght, giving its position to 1 of the spawned objects.
/// </summary>
public class PlacementManager : MonoBehaviour
{

    public Action OnStoredSuccesfully;
    private int x, y;
    public int Row = 1, Line=1 ;        //set in the editor

    float _timePassed;
    public float _spawnInterval;
    public float _lengthToMove;
    public GameObject GO_Indicator;
    private List<GameObject> _bufferList=  new List<GameObject>();
    Vector3 _originalPos,_originalLocalPos;
    StockPileManager _stockPileInstance;

    List<Material> _materials = new List<Material>();
    private void Awake()
    {
        _materials.Add(Resources.Load<Material>("Materials/TypesOfTiles/MatCoal") as Material);
        _materials.Add(Resources.Load<Material>("Materials/TypesOfTiles/MatIron") as Material);
        _materials.Add(Resources.Load<Material>("Materials/TypesOfTiles/MatGold") as Material);
        _originalPos = GO_Indicator.transform.position;
        _originalLocalPos = GO_Indicator.transform.localPosition ;
        _stockPileInstance = GetComponent<StockPileManager>();
        GO_Indicator.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnEnable()
    {
        _stockPileInstance.OnDeposit += addToBufferList;
        _stockPileInstance.OnWithDraw += RemoveCashedGO;
        var EM = GetComponent<ElevatorManager>();
        if (EM!=null)
        {
            GetComponent<ElevatorManager>().OnStateChanged += setOriginal;
        }
       
    }

    private void OnDisable()
    {
        _stockPileInstance.OnDeposit -= addToBufferList;
        _stockPileInstance.OnWithDraw -= RemoveCashedGO;
        var EM = GetComponent<ElevatorManager>();
        if (EM != null)
        {
            GetComponent<ElevatorManager>().OnStateChanged -= setOriginal;
        }

    }
    // Update is called once per frame
    void Update()
    {

        if (_bufferList.Count>0) {
            doRainFallEffect();
        }
        
    }
    private void setOriginal(ElevatorManager.State a) {
        if (a == ElevatorManager.State.Loading|| a == ElevatorManager.State.Unloading)
        {
            _originalPos =  transform.TransformPoint(_originalLocalPos) ;
            x = 0;
            y = 0;
        }
        

    }

    void addToBufferList(int amount,TileManager.TypeMetal metal) {
        for (int i = 0; i < amount; i++)
        {
            var go = Instantiate(GO_Indicator, gameObject.transform);
            if (metal == TileManager.TypeMetal.coal)
                go.GetComponent<MeshRenderer>().material = _materials[0];
            if (metal == TileManager.TypeMetal.iron)
                go.GetComponent<MeshRenderer>().material = _materials[1];
            if (metal == TileManager.TypeMetal.gold)
                go.GetComponent<MeshRenderer>().material = _materials[2];
            _bufferList.Add(go);
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
            go.name = "Tile At:" +x+"," + y;
            go.AddComponent<EnableIsKinematicAfterTime>().OnSuccefullyStored += addToCache;

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


    public List<GameObject> cashedGO = new List<GameObject>();
    List<KeyValuePair<Vector2, Rigidbody>> tileAtPos = new List<KeyValuePair<Vector2, Rigidbody>>();
    private void addToCache(GameObject go) {
        cashedGO.Add(go);
        

        var str = go.name.Split(':', ',');
        Vector2 vector2LocalPos = new Vector2(Int32.Parse( str[1]), Int32.Parse(str[2]));
        tileAtPos.Add(new KeyValuePair<Vector2, Rigidbody>(vector2LocalPos, go.GetComponent<Rigidbody>() ));

        go.GetComponent<EnableIsKinematicAfterTime>().OnSuccefullyStored -= addToCache;
        OnStoredSuccesfully?.Invoke();
        //Debug.Log("IsInvoking" + go.GetComponent<EnableIsKinematicAfterTime>().OnSuccefullyStored.GetInvocationList().Length);
        //Debug.Log("addedToCache");
    }


    int removeX=0, removeY=0;
    private void RemoveCashedGO(int amount) {
        if (amount > cashedGO.Count)
        {
            return;
        }
        for (int i = 0; i < amount; i++)
        {
            //Debug.Log("RemoveCashedGO amount" + amount);
            var lookup = tileAtPos.ToLookup(kvp => kvp.Key, kvp => kvp.Value);

            foreach (Rigidbody item in lookup[new Vector2(removeX, removeY)])
            {
                item.isKinematic = false;
                //Debug.Log("Test " + item.name);
            }



            //cashedGO.RemoveAt(0);
            removeX++;
            if (removeX == Row)
            {
                removeX = 0;
                removeY++;
            }
            if (removeY == Line)
            {
                removeY = 0;
            }
        }


        for (int i = 0; i < amount; i++)
        {
            var temp = cashedGO[0];
            cashedGO.RemoveAt(0);
            Destroy(temp);
        }
        tileAtPos.RemoveRange(0, amount);
        //Debug.Log("Im Called");

    }
}
