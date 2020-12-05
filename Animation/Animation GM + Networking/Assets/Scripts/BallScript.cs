using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using Photon.Realtime;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    PhotonView pv;
    

    void Start()
    {

        Rigidbody ballRB = GetComponent<Rigidbody>();
        transform.position = transform.position + Camera.main.transform.forward * 2;
        //ballRB.AddForce(gameObject.transform.forward * 10f);
        ballRB.velocity = Camera.main.transform.forward * 40;
        Destroy(this, 10f);
    }

    public void shootBall(Vector3 pos, Vector3 direction)
    {
        
    }

}
