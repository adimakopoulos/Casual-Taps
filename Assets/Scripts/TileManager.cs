using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    int maxHealth;
    int health;
    private int ironOrePieces;
    public GameObject BrokenVersion;
    public enum TypeMetal { iron , gold , coal };
    public TypeMetal metal;

    public Material currMaterial;

    private void Awake()
    {

        maxHealth = GameMasterManager.GMMInstance.myStats.TileHealth;
        Health = GameMasterManager.GMMInstance.myStats.TileHealth;
        MetalPieces = 9;
        setTypeMaterial();


    }

    private void setTypeMaterial()
    {
        Utils.Rarity rarity =  Utils.GetRandomRarity();
        if (rarity == Utils.Rarity.Legendary)
        {
            metal = TypeMetal.gold;
        }
        else if (rarity == Utils.Rarity.Rare)
        {
            metal = TypeMetal.iron;
        }
        else if (rarity == Utils.Rarity.Common)
        {
            metal = TypeMetal.coal;
        }



   
        if (metal == TypeMetal.gold)
        {

            currMaterial = Resources.Load<Material>("Materials/MatGold") as Material;
            GetComponent<MeshRenderer>().material = currMaterial;
        }
        if (metal == TypeMetal.iron)
        {

            currMaterial = Resources.Load<Material>("Materials/MatIron") as Material;
            GetComponent<MeshRenderer>().material = currMaterial;
        }
        if (metal == TypeMetal.coal)
        {

            currMaterial = Resources.Load<Material>("Materials/MatCoal") as Material;
            GetComponent<MeshRenderer>().material = currMaterial;
        }

    }

    private void OnEnable()
    {
        SimpleGameEvents.OnPickAxeImpact += doParticles;

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
            var go = Instantiate(BrokenVersion, gameObject.transform.position, gameObject.transform.rotation);
            go.GetComponent<TileBrokenManager>().metalMaterial = currMaterial;
            
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
