using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControl : MonoBehaviour
{
    PlaneScript plane;

    Vector3 Velocity  = new Vector3(0,0,0);
    Vector3 Accelleration = new Vector3(0, -9.8f, 0);
    float d1;
    float d2;
    private float Mass = 1f;
    readonly float radius = 0.5f;
    readonly float coefficiantOfRestitution = 0.6f;
    float m1 = 1f;
    float m2 = 1f;
    float timeOfImpact;
    Vector3 previousPosition;

    // Start is called before the first frame update
    void Start()
    {
       // plane = FindObjectOfType<PlaneScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //planeCollision();
        Velocity += Accelleration * Time.deltaTime;
        previousPosition = transform.position;
        transform.position += Velocity * Time.deltaTime;
    }

    public bool collidesWith(SphereControl otherSphere)
    {
        d1 = Vector3.Distance(otherSphere.previousPosition, previousPosition);
        d2 = Vector3.Distance(transform.position, otherSphere.transform.position) - (radius + otherSphere.radius);
        return Vector3.Distance(transform.position, otherSphere.transform.position) < (radius + otherSphere.radius);
    }

    public void sphereCollision(SphereControl sphere, SphereControl otherSphere)
    {
        print("Sphere Collision is called");

        Vector3 normal;
        Vector3 pointOfImpact;
        
        //collision occurs
        normal = (otherSphere.transform.position - sphere.transform.position).normalized;
        pointOfImpact = transform.position + (radius * normal);

         Vector3 v1 = ParallellComp(Velocity, normal) + PerpendicularComp(Velocity, normal);
         Vector3 v2 = ParallellComp(Velocity, normal) + PerpendicularComp(Velocity, normal);

         Vector3 u1 = ParallellComp(v1, normal);
         Vector3 u2 = ParallellComp(v2, normal);

         Vector3 para = ParallellComp(Velocity, normal);
         Vector3 perp = PerpendicularComp(Velocity, normal);

         v1 = (m1 - m2 / m1 + m2) * u1 + (2 * m2 / m1 + m2) * u2;
         v2 = (m2 - m1 / m1 + m2) * u2 + (2 * m1 / m1 + m2) * u1;


        timeOfImpact = Time.deltaTime * (d1 / (d1 - d2));
        transform.position -= Velocity * (Time.deltaTime - timeOfImpact);

        Velocity = perp - coefficiantOfRestitution * para;

        transform.position += Velocity * (Time.deltaTime - timeOfImpact);


        //print(v1);
        //print(v2);
    }

    public void planeCollision(PlaneScript plane)
    {
        float d1 = plane.DistanceTo(previousPosition) - radius;
       
        //float distanceFromCenterToPlane = plane.DistanceTo(transform.position);
        float d2 = plane.DistanceTo(transform.position) - radius;

        if (d2 <= 0)
        {
            Vector3 para = ParallellComp(Velocity, plane.NormalToPlane);
            Vector3 perp = PerpendicularComp(Velocity, plane.NormalToPlane);

            float timeOfImpact = Time.deltaTime * (d1 / (d1 - d2));
            transform.position -= Velocity * (Time.deltaTime - timeOfImpact);

            Velocity = perp - coefficiantOfRestitution * para;

            transform.position += Velocity * (Time.deltaTime - timeOfImpact);
        }
    }//end of planeCollision()

    private Vector3 ParallellComp(Vector3 vec, Vector3 normal)
    {
        return Vector3.Dot(vec, normal) * normal;
    }

    private Vector3 PerpendicularComp(Vector3 vec, Vector3 normal)
    {
        return vec - ParallellComp(vec, normal);
    }

}
