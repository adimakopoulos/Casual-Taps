using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    int maxHealth;
    int health;
    public GameObject BrokenVersion;



    private void Awake()
    {
        maxHealth = GameMasterManager.GMMInstance.myStats.TileHealth;
        Health = GameMasterManager.GMMInstance.myStats.TileHealth;
    }
    private void OnDisable()
    {


    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(int dmg) {
        Health -= dmg;

        if (Health <= 0) {
            Instantiate(BrokenVersion, gameObject.transform.position, gameObject.transform.rotation);
            SimpleGameEvents.OnTileDestroy?.Invoke(this);
            Destroy(this.gameObject);
        }
    }




    //--Get Set--
    public int Health { get => health; set => health = value; }
    public int MaxHealth { get => maxHealth;  }
}
