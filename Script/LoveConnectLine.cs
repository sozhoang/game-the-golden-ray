using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveConnectLine : MonoBehaviour
{
    LineRenderer line;
    EdgeCollider2D col;
    public List<Vector2> linePoints =  new List<Vector2>();
    void Start()
    {
        line = GetComponent<LineRenderer>();
        col = GetComponent<EdgeCollider2D>();
    }

    void Update()
    {
        linePoints[0] = line.GetPosition(0);
        linePoints[1] = line.GetPosition(1);
        col.SetPoints(linePoints);
    }
}
