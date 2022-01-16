using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    int maxHealth;
    int health;
    private int ironOrePieces;
    public GameObject BrokenVersion;
    public enum TypeMetal { iron , gold };
    public TypeMetal metal;



    private void Awake()
    {
        maxHealth = GameMasterManager.GMMInstance.myStats.TileHealth;
        Health = GameMasterManager.GMMInstance.myStats.TileHealth;
        MetalPieces = 9;
        metal =(TypeMetal) Random.Range(0, 2);
    }
    private void OnEnable()
    {
        SimpleGameEvents.OnPickAxeImpact += doParticles;
        if (metal== TypeMetal.gold)
            GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/MatGold") as Material;
    }
    private void OnDisable()
    {
        SimpleGameEvents.OnPickAxeImpact -= doParticles;

    }
    private void doParticles(TileManager a) {
        if(a.GetInstanceID() == this.GetInstanceID())
            GetComponentInChildren<ParticleSystem>().Play();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(int dmg) {
        Health -= dmg;

        if (Health <= 0) {
            Instantiate(BrokenVersion, gameObject.transform.position, gameObject.transform.rotation);

            SimpleGameEvents.OnTileDestroyed?.Invoke(this);
            Destroy(this.gameObject);

        }
    }




    //--Get Set--
    public int Health { get => health;
        set {
            if (value >= 0) { 
                health = value; }
            else { 
                health = 0; }
        } 
    }
    public int MaxHealth { get => maxHealth;  }
    public int MetalPieces { get => ironOrePieces; set => ironOrePieces = value; }
}
