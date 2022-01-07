using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform StartPos;
    public Transform EndPos;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, StartPos.position);
        lineRenderer.SetPosition(1, EndPos.position);
    }
}
