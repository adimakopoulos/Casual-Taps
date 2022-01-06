using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxeManager : MonoBehaviour
{
    BoxCollider myBC;
    Rigidbody myRB;
    AudioSource myAudioSource;
    Vector3 originalPos; 
    private void Awake()
    {
        //TODO: Remove GetComponents. Create Prefab and cash the references there.
        myBC = GetComponent<BoxCollider>();
        myRB = GetComponent<Rigidbody>();
        myAudioSource = GetComponent<AudioSource>();
        originalPos = gameObject.transform.position;
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        SimpleGameEvents.OnStartGameplay += enableColider;
        SimpleGameEvents.OnPickAxeRelease += resetPos;

    }
    private void OnDisable()
    {
        SimpleGameEvents.OnStartGameplay -= enableColider;
        SimpleGameEvents.OnPickAxeRelease -= resetPos;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ColumnBase")
        {
            return;
        }
        else {
            collision.gameObject.GetComponent<TileManager>().takeDamage(GameMasterManager.GMMInstance.myStats.Damage);
        }
        
        myBC.enabled = false;
        myRB.isKinematic = true;
        myAudioSource.Play();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void enableColider() {
        myBC.enabled = true;
    }
    private void resetPos() {
        myBC.enabled = true;
        myRB.isKinematic = false;
        gameObject.transform.position = originalPos;


    }
}
