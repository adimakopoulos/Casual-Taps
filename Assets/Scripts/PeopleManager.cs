using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : MonoBehaviour
{

    public People PeopleData;
    List<GameObject> _goPeople = new List<GameObject>();
    public Action<TransferOrder> OnNewTransferJob;

    public List<Transform> PointsOfIntrest;// Set points of intrest in inspector
    public GameObject personPrefab;
    private List<IStockPile> myStockPiles = new List<IStockPile>();
    private Queue<TransferOrder> _jobs = new Queue<TransferOrder>();
    private int pendingPeices= 0;
    private void Awake()
    {
        personPrefab.SetActive(false);
        //gameObject.enable


    }
    private void Start()

    {
        LoadData();
        for (int i = 0; i < PeopleData.NumOfPeople; i++)
        {
            createWorker();
        }
        findStockPiles();
        InvokeRepeating("chekForNewJob", 2f, 2f);
        InvokeRepeating("checkForIdleWorkes", 3f, 1.5f);
        
    }

    private void OnDisable () {
        foreach (var item in _goPeople)
        {
            item.GetComponent<WorkerManager>().OnJobCompleted -= completeJob;
        }
    }
    

    /// <summary>
    /// gets called Periodicaly with InvokeRepeating
    /// </summary>
    private void chekForNewJob(){

        var countOfStoredPieces = PointsOfIntrest[0].GetComponent<PlacementManager>()?.cashedGO.Count;
        if (countOfStoredPieces >= PeopleData.CarryingCapacity + pendingPeices) {
            _jobs.Enqueue(createJob());
            pendingPeices += PeopleData.CarryingCapacity;
            //Debug.Log("Job created in " + gameObject.name + " With cashedGO.Count" + PointsOfIntrest[0].GetComponent<PlacementManager>()?.cashedGO.Count);
            return;
        }
        countOfStoredPieces = PointsOfIntrest[0].GetComponent<LoosePiecesManager>()?.LoosePieces.Count;
        if (countOfStoredPieces >= PeopleData.CarryingCapacity + pendingPeices)
        {
            _jobs.Enqueue(createJobWithManySuppliers(PeopleData.CarryingCapacity));
            pendingPeices += PeopleData.CarryingCapacity;
            //Debug.Log("Job created in " + gameObject.name + " With LoosePieces.Count" + PointsOfIntrest[0].GetComponent<LoosePiecesManager>()?.LoosePieces.Count);
            return;
        }

    }

    private TransferOrder createJobWithManySuppliers(int NumOfSupply)
    {
        var suppliers = new Vector3[NumOfSupply];
        var CashedManager = PointsOfIntrest[0].GetComponent<LoosePiecesManager>();
        for (int i = 0; i < NumOfSupply; i++)
        {
            suppliers[i] = CashedManager.GetLocationOfPieceWithIndex(i+pendingPeices);
        }

        var consumer = PointsOfIntrest[1].transform.position;


        var job = new TransferOrder(suppliers, consumer, PeopleData.CarryingCapacity);
        return job;
    }



    private void checkForIdleWorkes() {
        if (_jobs.Count>0) { 
        foreach (var worker in _goPeople)
        {
            var result = worker.GetComponent<WorkerManager>();
            if (result == null) {
                Debug.Log("worker.GetComponent<WorkerManager>(); Faild to get the component");
                return;
            }
            
            if (result.GetState() == WorkerManager.State.idle) {
                
                result.setToWork(_jobs.Dequeue());
                return;
            }


        }
}

    }
    private void completeJob(TransferOrder order) {
        if (order.Suppliers?.Length > 0)
            return;//because its already subtracked;
        pendingPeices -= order.Ammount;
    }
    private void SupplierReached()
    {
        pendingPeices --;
    }

    /// <summary>
    /// points of intrest are set manualy in the inspector.<br>
    /// the first point should always be the Supplying Stockpile and the second should be the Consumer.
    /// </summary>
    private void findStockPiles() {
        foreach (var go in PointsOfIntrest) {
            var sp = go.GetComponent<IStockPile>();
            if (sp != null && sp is IStockPile) {
                myStockPiles.Add(sp);
                //Debug.Log("I have found a IStockPile ");
            }
        }
    }
    private void createWorker()
    {
        var go = Instantiate(personPrefab, gameObject.transform);
        go.SetActive(true);
        go.GetComponent<WorkerManager>().OnJobCompleted += completeJob;
        go.GetComponent<WorkerManager>().OnSupplierReached += SupplierReached;
        go.GetComponent<MoveToPointManager>().Speed = PeopleData.speedNormal;
        go.GetComponent<MoveToPointManager>().SpeedCarrying = PeopleData.speedCarrying;
        _goPeople.Add(go);
    }


    // Update is called once per frame
    void Update()
    {
        

        //randVect3 = new Vector3(UnityEngine.Random.Range(0f, 5f), gameObject.transform.position.y, UnityEngine.Random.Range(0f, 5f));

    }



    void LoadData() {
        var data = GameMasterManager.GMMInstance.myPeopleGroups;
        foreach (var item in data)
        {

            if (String.Equals(item.Name,gameObject.name) ) { 
                
                PeopleData = item;
            }
            
        }
      
    }

    public void IncreaceWorker() {
        PeopleData.NumOfPeople += 1;
        createWorker();
    }

    /// <summary>
    /// the fitst point of intrest is always the supplier.
    /// this PointsOfIntrest[] is set in the inspector.
    /// </summary>
    /// <returns></returns>
    private TransferOrder createJob() {

        var supplier = PointsOfIntrest[0].transform.position;
        var consumer = PointsOfIntrest[1].transform.position;
        var job = new TransferOrder(supplier, consumer, PeopleData.CarryingCapacity);
        return job;
    }

    public IStockPile GetSupplier() {
        return myStockPiles[0];
    }
    public IStockPile GetConsumer()
    {
        return myStockPiles[1];
    }



    public void UpdateWorkerStats_Speed() { 
        foreach (var worker in _goPeople) {
            worker.GetComponent<MoveToPointManager>().Speed = PeopleData.speedNormal;
            worker.GetComponent<MoveToPointManager>().SpeedCarrying = PeopleData.speedCarrying;
        }
    }



    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawLine(gameObject.transform.position, randVect3);
        //Gizmos.DrawSphere(randVect3, 0.5f);
    }
}



