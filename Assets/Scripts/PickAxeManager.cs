using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxeManager : MonoBehaviour
{
    BoxCollider myBC;
    Rigidbody myRB;
    AudioSource myAudioSource;
    int _damage = 10;
    public Vector3 originalPos; 
    private void Awake()
    {
        myBC = GetComponent<BoxCollider>();
        myRB = GetComponent<Rigidbody>();
        myAudioSource = GetComponent<AudioSource>();
        originalPos = gameObject.transform.position;
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        SimpleActions.OnStartGame += enableColider;


    }
    private void OnDisable()
    {
        SimpleActions.OnStartGame -= enableColider;

    }
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<TileManager>().takeDamage(_damage);
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
        if (Input.GetKeyDown(KeyCode.Space)) {
            resetPos();
        }
    }

    private void enableColider() {
        myBC.enabled = true;
    }
    private void resetPos() {
        myBC.enabled = true;
        myRB.isKinematic = false;
        gameObject.transform.position = originalPos;
        Debug.Log("gameObjectPos:"+gameObject.transform.position);
        Debug.Log("originalPos:"+originalPos);

    }
}
