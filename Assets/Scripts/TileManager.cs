using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    int health= 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnDisable()
    {
        Debug.Log("nooo");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(int dmg) {
        health -= dmg;
        Debug.Log(health);
        if (health <= 0) {
            Destroy(this.gameObject);
        }
    }
}
