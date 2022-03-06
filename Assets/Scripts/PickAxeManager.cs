using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxeManager : MonoBehaviour
{
    MeshRenderer myMR;
    BoxCollider myBC;
    Rigidbody myRB;
    AudioSource myAudioSource;
    Vector3 originalPos;
    Cinemachine.CinemachineImpulseSource impulseSource;
    private void Awake()
    {
        //TODO: Remove GetComponents. Create Prefab and cash the references there.
        myMR = GetComponent<MeshRenderer>();
        myBC = GetComponent<BoxCollider>();
        myRB = GetComponent<Rigidbody>();
        myRB.solverVelocityIterations = 12;
        myRB.solverIterations = 12;

        myAudioSource = GetComponent<AudioSource>();
        originalPos = gameObject.transform.position;
        impulseSource = GetComponent<Cinemachine.CinemachineImpulseSource>();
    }
    private void OnEnable()
    {
        SimpleGameEvents.OnStartGameplay += enableColider;
        SimpleGameEvents.OnPickAxeRelease += resetPos;
        SimpleGameEvents.OnTileDestroyed += generateCameraShake;
        SimpleGameEvents.OnLevelComplete += hidePickAxe;
        SimpleGameEvents.OnStartGameplay += showPickAxe ;
    }
    private void OnDisable()
    {
        SimpleGameEvents.OnStartGameplay -= enableColider;
        SimpleGameEvents.OnPickAxeRelease -= resetPos;
        SimpleGameEvents.OnTileDestroyed -= generateCameraShake;
        SimpleGameEvents.OnLevelComplete -= hidePickAxe;
        SimpleGameEvents.OnStartGameplay -= showPickAxe;
    }

    bool hasCollidedOnce;
    private void  OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject.name.Contains("Tile")) || hasCollidedOnce)
            return;
        hasCollidedOnce = true;
        Debug.Log("collisions" + collision.rigidbody.name);


        myBC.enabled = false;
        myRB.isKinematic = true;
        myRB.velocity = myRB.velocity * -0.5f;
        myAudioSource.Play();

        collision.gameObject.GetComponent<TileManager>().takeDamage(GameMasterManager.GMMInstance.myStats.Damage);
        SimpleGameEvents.OnPickAxeImpact?.Invoke(collision.gameObject.GetComponent<TileManager>());

    }


    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        //if (myRB.velocity < 0f) { hasCollidedOnce = true; }
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void generateCameraShake(TileManager var) {
        impulseSource.GenerateImpulse();
    }
    private void enableColider() {
        Debug.Log("enableColider");
        myBC.enabled = true;
    }
    private void resetPos() {
        hasCollidedOnce = false;
        myBC.enabled = true;
        myRB.isKinematic = false;
        gameObject.transform.position = originalPos;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3 (0, -5, 0);

    }

    private void hidePickAxe()
    {
        myMR.enabled = false;
        gameObject.transform.position = originalPos;
    }
    private void showPickAxe()
    {
        myMR.enabled = true;

    }

    //        if (!(collision.gameObject.name.Contains("Tile"))|| hasCollidedOnce )
    //         return ;
    //    hasCollidedOnce = true;
    //    Debug.Log("collisions" + collision.rigidbody.name);


    //    //myBC.enabled = false;
    //    //myRB.isKinematic = true;
    //    myRB.velocity = myRB.velocity* -0.5f;
    //    myAudioSource.Play();

    //    collision.gameObject.GetComponent<TileManager>().takeDamage(GameMasterManager.GMMInstance.myStats.Damage);
    //SimpleGameEvents.OnPickAxeImpact?.Invoke(collision.gameObject.GetComponent<TileManager>());
}
