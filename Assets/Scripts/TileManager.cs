using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    int health= 10;
    public GameObject BrokenVersion; 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnDisable()
    {


    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(int dmg) {
        health -= dmg;

        if (health <= 0) {
            Instantiate(BrokenVersion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
