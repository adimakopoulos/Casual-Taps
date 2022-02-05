using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : MonoBehaviour
{

    People people;
    List<GameObject> goPeople =new List<GameObject>();
    public Action<Vector3> OnNewTargetToMove;

    public List<Transform> PointsOfIntrest;// Set points of intrest in inspector

    public GameObject personPrefab;
    private void Awake()
    {
        personPrefab.SetActive(false);
        //gameObject.enable


    }
    private void Start()

    {
        LoadData();
        for (int i = 0; i < people.NumOfPeople; i++)
        {
            createWorker();

        }
    }

    private void createWorker()
    {
        var go = Instantiate(personPrefab, gameObject.transform);
        go.SetActive(true);
        go.GetComponent<MoveToPointManager>().Speed = people.speedNormal;
        goPeople.Add(go);
    }

    float timeElasped=0;
    Vector3 randVect3;
    // Update is called once per frame
    void Update()
    {

        if (timeElasped > 3f)
        {

            randVect3 = new Vector3(UnityEngine.Random.Range(0f, 5f), gameObject.transform.position.y, UnityEngine.Random.Range(0f, 5f));
            
            OnNewTargetToMove?.Invoke(randVect3);
            
            timeElasped =0;
        }
        timeElasped+=Time.deltaTime;
    }



    void LoadData() {
        var data = GameMasterManager.GMMInstance.myPeopleGroups;
        foreach (var item in data)
        {

            if (String.Equals(item.Name,gameObject.name) ) { 
                
                people = item;}
            
        }
      
    }

    public void IcreaceWorker() {
        people.NumOfPeople += 1;
        createWorker();
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(gameObject.transform.position, randVect3);
        Gizmos.DrawSphere(randVect3, 0.5f);
    }
}

internal class TransferJob {
    List<Transform> points;

    TransferJob(List<Transform> WorldPosPoints,int CarryAmmount){
        
    }
}