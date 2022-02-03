using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/// <summary>
/// This Class is Stored to JsonFile.
/// </summary>
public class People 
{

    public string Name;
    public int NumOfPeople;
    public int CarryingCapacity;
    public float speedNormal;
    public float speedCarrying;

    public People(string name)
    {
        Name = name;
        NumOfPeople = 1;
        CarryingCapacity = 1;
        this.speedNormal = 0.01f;
        this.speedCarrying = 0.005f;
    }
}
