using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : MonoBehaviour
{

    People people;
    List<GameObject> goPeople =new List<GameObject>();
    public Action<Vector3> OnNewTargetToMove;

    public GameObject personPrefab;
    private void Awake()
    {
        



    }
    private void Start()

    {
        LoadData();
        for (int i = 0; i < people.NumOfPeople; i++)
        {
            goPeople.Add(Instantiate(personPrefab, gameObject.transform));



        }
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

            if (String.Equals(item.Name,gameObject.name) ) { }
            people = item;
        }
      
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(gameObject.transform.position, randVect3);
        Gizmos.DrawSphere(randVect3, 0.5f);
    }
}
