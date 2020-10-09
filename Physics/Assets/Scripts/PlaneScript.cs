using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    Vector3 PointOnPlane;
    public Vector3 NormalToPlane { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        DefinePoint(new Vector3(0, -1, 0), new Vector3(0.03f, 1, 0));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DefinePoint(Vector3 point, Vector3 normal)
    {
        PointOnPlane = point;
        NormalToPlane = normal.normalized;
        transform.position = PointOnPlane;
        transform.up = NormalToPlane;
    }

    public float DistanceTo(Vector3 point)
    {
        Vector3 pointOnPlaneToPoint = point - PointOnPlane;
        return Vector3.Dot(pointOnPlaneToPoint, NormalToPlane);
    }
}
