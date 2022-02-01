using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : MonoBehaviour
{

    People people;
    List<GameObject> goPeople =new List<GameObject>();
    public GameObject personPrefab;
    private void Awake()
    {


        people = new People();
        people.NumOfPeople = 5;


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
