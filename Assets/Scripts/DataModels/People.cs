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
        NumOfPeople = 1+3;
        CarryingCapacity = 1+9;
        this.speedNormal = 2f;
        this.speedCarrying = 1f;
    }
}
