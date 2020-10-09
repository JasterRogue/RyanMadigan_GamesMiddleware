using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ObjectManagerScript : MonoBehaviour
{
    SphereControl[] allSpheres;
    PlaneScript[] allPlanes;

    // Start is called before the first frame update
    void Start()
    {
        //allSpheres = FindObjectsofType<PhysicsControl>();
        allSpheres = FindObjectsOfType(typeof(SphereControl)) as SphereControl[];
        allPlanes = FindObjectsOfType(typeof(PlaneScript)) as PlaneScript[];
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < allSpheres.Length-1; i++)
            for (int j = i+1;j<allSpheres.Length;j++)
        {

                SphereControl sphere1, sphere2;
                sphere1 = allSpheres[i];
                sphere2 = allSpheres[j];
                if (sphere1.collidesWith(sphere2))
                {
                    print("Collision");
                    sphere1.sphereCollision(sphere1, sphere2);
                }
                    
                //print(allSpheres[i]);
        }//end of sphere for loop

       /* for (int i = 0; i < allPlanes.Length; i++)
        {
            print(allPlanes[i]);
        }*/

    }
}
