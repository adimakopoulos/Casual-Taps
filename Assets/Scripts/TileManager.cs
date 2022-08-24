using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    int maxHealth;
    int health;
    private int ironOrePieces;
    public GameObject BrokenVersion;
    public enum TypeMetal { iron , gold , coal , NoMaterial};
    public TypeMetal metal;
    private GameObject myInstance;

    public Material currMaterial;
    public static int ID = 0;
     
    private void Awake()
    {
        ID++;
        maxHealth = GameMasterManager.GMMInstance.myStats.TileHealth;
        Health = GameMasterManager.GMMInstance.myStats.TileHealth;
        MetalPieces = 9;
        setTypeMaterial();
     
        GetComponent<Rigidbody>().solverVelocityIterations = 12;
        GetComponent<Rigidbody>().solverIterations = 12;
        myInstance = this.gameObject;

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
            currMaterial = Resources.Load<Material>("Materials/TypesOfTiles/MatGold") as Material;
            GetComponent<MeshRenderer>().material = currMaterial;
        }
        if (metal == TypeMetal.iron)
        {

            currMaterial = Resources.Load<Material>("Materials/TypesOfTiles/MatIron") as Material;
            GetComponent<MeshRenderer>().material = currMaterial;
        }
        if (metal == TypeMetal.coal)
        {

            currMaterial = Resources.Load<Material>("Materials/TypesOfTiles/MatCoal") as Material;
            GetComponent<MeshRenderer>().material = currMaterial;
        }

    }

    private void OnEnable()
    {
        SimpleGameEvents.OnHasTileTakenDamage += doParticles;
        SimpleGameEvents.OnPickAxeImpact += takeDamage;

    }
    private void OnDisable()
    {
        SimpleGameEvents.OnHasTileTakenDamage -= doParticles;
        SimpleGameEvents.OnPickAxeImpact -= takeDamage;
    }
    private void doParticles(TileManager a) {
        if (a.GetInstanceID() == this.GetInstanceID() && a.health!=0)
            GetComponentInChildren<ParticleSystem>().Play();
    }

    public void takeDamage(TileManager tm) {
        
        if (tm.GetInstanceID() == this.GetInstanceID())
        {

            Health -= GameMasterManager.GMMInstance.myStats.Damage;
            SimpleGameEvents.OnHasTileTakenDamage?.Invoke(this);
            if (Health == 0)
            {
                ReplaceAndDestroyThisTile();
            }
        }
        else {
            return;
        }
    }

    private void ReplaceAndDestroyThisTile()
    {
        try
        {
            var go = Instantiate(BrokenVersion, gameObject.transform.position, gameObject.transform.rotation);
            go.GetComponent<TileBrokenManager>().metalMaterial = currMaterial;
            SimpleGameEvents.OnTileDestroyed?.Invoke(this);
            destroySelfInstance();
        }
        catch (Exception e)
        { 
            throw new System.Exception("{0} Exception caught.", e);
        }
    }

    private async void destroySelfInstance()
    {
        await Task.Delay(1); // 1 second delay
        Debug.Log("destroySelfInstance of object:"+ this.name);
        Destroy(myInstance);
    }

    private void OnDestroy()
    {
        gameObject.name += "TBdeleted";
    }

    //--Get Set--
    public int Health { get => health;
        set {
            if (value >= 0) { 
                health = value; }
            else {
                Debug.Log("value < 0");
                health = 0; }
        } 
    }
    public int MaxHealth { get => maxHealth;  }
    public int MetalPieces { get => ironOrePieces; set => ironOrePieces = value; }
}
