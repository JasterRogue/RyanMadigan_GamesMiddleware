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
        allSpheres = FindObjectsOfType(typeof(SphereControl)) as SphereControl[];
        allPlanes = FindObjectsOfType(typeof(PlaneScript)) as PlaneScript[];

        //allPlanes[0].DefinePoint(new Vector3(0, -1, 0), new Vector3(0.03f, 1, 0));
        //allPlanes[1].DefinePoint(new Vector3(-5.34f, 4.67f, 0.32f), new Vector3(90, 2, 90));
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

        for (int i = 0; i < allPlanes.Length; i++)
        {
           for(int j = 0; j < allSpheres.Length; j++)
            {
                allSpheres[j].planeCollision(allPlanes[i]);
            }
        }

    }
}
