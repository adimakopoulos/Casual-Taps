using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxeManager : MonoBehaviour
{
    BoxCollider myBC;
    int _damage = 5;
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
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void enableColider() {
        myBC = GetComponent<BoxCollider>();
        myBC.enabled = true;
    }
}
