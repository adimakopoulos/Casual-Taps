using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTest : MonoBehaviour
{
    System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();

    // Start is called before the first frame update
    void Start()
    {
        watch.Start();
        for (int i = 0; i < 100_000; i++)
        {
            var a = GetComponent<Renderer>().material.name;
        }
        watch.Stop();
        Debug.Log("ElapsedMilliseconds: " + watch.ElapsedMilliseconds*0.001);


        watch.Restart();
        Debug.Log("ElapsedMilliseconds: " + watch.ElapsedMilliseconds * 0.001);
        //watch.Start();
        for (int i = 0; i < 100_000; i++)
        {
            var a = GetComponent<RotateManager>();
        }
        watch.Stop();
        Debug.Log("ElapsedMilliseconds: " + watch.ElapsedMilliseconds * 0.001);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
