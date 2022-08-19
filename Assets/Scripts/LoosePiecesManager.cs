using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LoosePiecesManager : MonoBehaviour , IStockPile
{
    public List<GameObject> LoosePieces = new List<GameObject>();
    //public List<TileBrokenManager> BrokenPieceManagers = new List<TileBrokenManager>();
    public StockPile myStockPileData;


    private void Awake()
    {
        myStockPileData = new StockPile(0,0,0,1000);
    }
    private void OnEnable()
    {
        SimpleGameEvents.OnTileShutter += ListenforEvent;
    }
    private void OnDisable()
    {
        SimpleGameEvents.OnTileShutter -= ListenforEvent;

    }
    /// <summary>
    /// every time a tile breaks all the smaller pieces get added to this list.
    /// </summary>
    /// <param name="BPManager"></param>
    private void ListenforEvent(TileBrokenManager BPManager)
    {
        BPManager.On4SecondsPass += AddPiecesTolist;
        BPManager.transform.parent = transform;
            
    }

    private void AddPiecesTolist(TileBrokenManager BPManager)
    {
        BPManager.On4SecondsPass -= AddPiecesTolist;
        var array = BPManager.GetComponentsInChildren<Transform>();
        Destroy(array[0].gameObject);
        array = array.Skip(1).ToArray();//the first element is the parent tranform. I want only the childerns Transforms, so i skip it.
        foreach (var piece in array)
        {

            LoosePieces.Add(piece.gameObject);
            piece.transform.parent = this.gameObject.transform;
            
            var mat = Utils.GetTypeByMaterial(piece.GetComponent<Renderer>().material);
            Add1SmallPiece(mat);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add1SmallPiece(TileManager.TypeMetal typeMetal)
    {
        var isAbleToStore = myStockPileData.Deposit(typeMetal, 1);
        //Debug.Log("isAbleToStore= " + isAbleToStore + " //myStockPile.Total="+ myStockPileData.getCurentTotal());

    }

    public void RemovePiece(TileManager.TypeMetal typeMetal, int ammount)
    {
        throw new NotImplementedException();
    }

    public int CanTransact(TileManager.TypeMetal typeMetal, int amount)
    {
        throw new NotImplementedException();
    }

    public Dictionary<TileManager.TypeMetal, int> RemoveLastPieces(int amount)
    {
        if (LoosePieces.Count >= amount)
        {
            var Dic = new Dictionary<TileManager.TypeMetal, int>();
            Dic.Add(TileManager.TypeMetal.coal, 0);
            Dic.Add(TileManager.TypeMetal.iron, 0);
            Dic.Add(TileManager.TypeMetal.gold, 0);
            for (int i = 0; i < amount; i++)
            {
                if (LoosePieces[0].GetComponent<MeshRenderer>().material.name.Contains("Coal"))
                {
                    myStockPileData.Withdraw(TileManager.TypeMetal.coal, 1);
                    Dic[TileManager.TypeMetal.coal] += 1;
                    Destroy(LoosePieces[0]);
                    LoosePieces.RemoveAt(0);
                    continue;
                }
                if (LoosePieces[0].GetComponent<MeshRenderer>().material.name.Contains("Iron"))
                {
                    myStockPileData.Withdraw(TileManager.TypeMetal.iron, 1);
                    Dic[TileManager.TypeMetal.iron] += 1;
                    Destroy(LoosePieces[0]);
                    LoosePieces.RemoveAt(0);
                    continue;
                }
                if (LoosePieces[0].GetComponent<MeshRenderer>().material.name.Contains("Gold"))
                {
                    myStockPileData.Withdraw(TileManager.TypeMetal.gold, 1);
                    Dic[TileManager.TypeMetal.gold] += 1;
                    Destroy(LoosePieces[0]);
                    LoosePieces.RemoveAt(0);
                }
            }
            return Dic;



        }
        return null;
    }

    public GameObject GetInstance()
    {
        return this.gameObject;
    }

    public int GetAvailableStorage()
    {
        throw new NotImplementedException();
    }

    public Vector3 GetLocationOfPieceWithIndex(int index) {
        var loc = LoosePieces[index].GetComponent<Rigidbody>().worldCenterOfMass;
        var location = new Vector3(loc.x, this.gameObject.transform.position.y, loc.z);

       
        return location;
    }
    //public Vector3 GetLocationOfPiece(GameObject go) { 
    //    LoosePieces.Find(go).
    //}

    private void OnDrawGizmosSelected()
    {
        foreach (var item in LoosePieces)
        {
            Gizmos.color = Color.red;
            //Gizmos.DrawLine(gameObject.transform.position, randVect3);
            Gizmos.DrawSphere(item.GetComponent<Rigidbody>().worldCenterOfMass, 0.5f);

        }
    }

}
