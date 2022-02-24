using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    public Action<Vector3> OnNewDestination;
    public Action<TransferOrder> OnJobCompleted;
    public Action OnSupplierReached;//this gets called when handling multiple Suppliers
    public enum State { idle, working }
    State _state = State.idle;

    private TransferOrder _myOrders;
    public PeopleManager myGroup;
    private MoveToPointManager _myMoveToPointManager;
    public GameObject Piece;// set in inspector
    List<GameObject> Pieces = new List<GameObject>();

    private int IndexOfSuppliers;
    private void Awake()
    {

        _myMoveToPointManager = GetComponent<MoveToPointManager>();
    }
    private void OnEnable()
    {
        _myMoveToPointManager.OnDestinationReached += setNewOrders;
    }
    private void OnDisable()
    {
        _myMoveToPointManager.OnDestinationReached -= setNewOrders;
    }
    private void Update() { 
    
    }







    
    private void setNewOrders() {
        if (_myOrders == null)
            return;
        //When you have reached Supplier, Try To withdraw
        if (_myOrders.CurrentStage == TransferOrder.TranferStage.GoingToSupplier) {
            _myOrders.CurrentStage = TransferOrder.TranferStage.Withdrawing;
            var dic = myGroup.GetSupplier().RemoveLastPieces(myGroup.PeopleData.CarryingCapacity);
            showTilesPeices(dic);
            _myOrders.CurrentStage = TransferOrder.TranferStage.GoingToConsumer;
            OnNewDestination?.Invoke(_myOrders.Consumer);
            return;
        }
        //when you have reached Consumer, try  to deposit
        if (_myOrders.CurrentStage == TransferOrder.TranferStage.GoingToConsumer)
        {
            //if there is no space try again in 2 seconds
            if (myGroup.GetConsumer().GetAvailableStorage()< Pieces.Count) {
                Invoke("setNewOrders",2);
                Debug.Log("Invoke(setNewOrders,2)");
                return;
            }
            _myOrders.CurrentStage = TransferOrder.TranferStage.Depositing;
            foreach (var item in Pieces)
            {
                var type = item.GetComponent<Renderer>().material.name;
                if (type.Contains("Coal")) {
                    myGroup.GetConsumer().AddPiece(TileManager.TypeMetal.coal,1); 
                }
                if (type.Contains("Gold"))
                {
                    myGroup.GetConsumer().AddPiece(TileManager.TypeMetal.gold, 1);
                }
                if (type.Contains("Iron"))
                {
                    myGroup.GetConsumer().AddPiece(TileManager.TypeMetal.iron, 1);
                }

            }


            clearTilesPieces();
            _state = State.idle;
            OnJobCompleted?.Invoke(_myOrders);
            _myOrders = null;
            OnNewDestination?.Invoke(myGroup.transform.position);//return to home
            return;
        }

        //handle Multiple Suppliers
        if (_myOrders.CurrentStage == TransferOrder.TranferStage.GoingToSuppliers)
        {
            if (IndexOfSuppliers == _myOrders.GetNumOfSuppliers()) {
                _myOrders.CurrentStage = TransferOrder.TranferStage.GoingToConsumer;
                OnSupplierReached?.Invoke();
                showTilesPeices(myGroup.GetSupplier().RemoveLastPieces(1));
                OnNewDestination?.Invoke(_myOrders.Consumer);
                return;
            }
            //withrdaw
            OnSupplierReached?.Invoke();
            var dic = myGroup.GetSupplier().RemoveLastPieces(1);
            showTilesPeices(dic);
            
            OnNewDestination?.Invoke(_myOrders.Suppliers[IndexOfSuppliers]);
            IndexOfSuppliers++;
            return;
        }


    }



    public void setToWork(TransferOrder TO) {

        IndexOfSuppliers = 1; 
        _myOrders = TO;
        _state = State.working;
        OnNewDestination?.Invoke(_myOrders.FirstSupplier);

    }
    public State GetState() { 
        return _state;
    }
    private void clearTilesPieces() {
        foreach (var item in Pieces)
        {
            Destroy(item);
        }
        Pieces.Clear();
        //Debug.Log("Pieces.Clear();" + Pieces.Count);
    }

    float displacement = 0f;
    private void showTilesPeices(Dictionary<TileManager.TypeMetal,int> dic) {
        if (_myOrders.CurrentStage != TransferOrder.TranferStage.GoingToSuppliers) { 
            displacement = 0f;
        }
        
        foreach (var item in dic)
        {
            
            for (int i = 0; i < item.Value; i++)
            {
                var go = Instantiate(Piece,this.gameObject.transform);
                Pieces.Add(go);
                go.gameObject.SetActive(true);
                go.GetComponent<Renderer>().material = Utils.GetMaterialByName(item.Key.ToString()) as Material;
                go.transform.localPosition = new Vector3(go.transform.localPosition.x, go.transform.localPosition.y+ displacement, go.transform.localPosition.z);
                displacement += 0.15f;
            }


        }
        foreach (var item in Pieces) {
            //item.gameObject.SetActive(true);
            //item.GetComponent<Renderer>().material = Utils.GetMaterialByName(TileManager.TypeMetal);
        }
    }



    //------------getset------------------
    public TransferOrder GetCurrentOrders()
    {
        return _myOrders;
    }
     

}
